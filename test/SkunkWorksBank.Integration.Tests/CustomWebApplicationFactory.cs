
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SkunkWorksBank.Repository.SharedContext.Data;
using Testcontainers.MsSql;

namespace SkunkWorksBank.API.Integration.Tests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private IServiceScope scope;
        private readonly MsSqlContainer sqlContainer =
           new MsSqlBuilder()
               .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
               .WithPassword("Strong@123")
               .WithEnvironment("ACCEPT_EULA", "Y")
               .WithEnvironment("MSSQL_PID", "Express")
               .WithEnvironment("MSSQL_AGENT_ENABLED", "true")
               .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                sqlContainer.StartAsync().GetAwaiter().GetResult();

                var baseCs = sqlContainer.GetConnectionString();

                var cs = new SqlConnectionStringBuilder(baseCs)
                {
                    TrustServerCertificate = true,
                    Encrypt = false
                }.ConnectionString;

                services.RemoveAll(typeof(DbContextOptions<AppDbContext>));

                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseSqlServer(cs);
                });
            });
        }

        public async Task InitializeAsync()
        {
            scope = Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            context.Database.Migrate();
        }
        async Task IAsyncLifetime.DisposeAsync()
        {
            scope?.Dispose();
            await sqlContainer.DisposeAsync();
        }
    }
}