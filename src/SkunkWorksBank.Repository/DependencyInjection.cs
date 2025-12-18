using Microsoft.Extensions.DependencyInjection;
using SkunkWorksBank.Domain.Shared.Data.Abstractions;
using SkunkWorksBank.Domain.Users.Repositories.Abstractions;
using SkunkWorksBank.Repository.SharedContext.Data;
using SkunkWorksBank.Repository.UserContext.Repositories;

namespace SkunkWorksBank.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
