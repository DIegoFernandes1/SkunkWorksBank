using Microsoft.EntityFrameworkCore;
using SkunkWorksBank.Domain.UserContext.Entities;
using SkunkWorksBank.Domain.Users.Entities;

namespace SkunkWorksBank.Repository.SharedContext.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);

            modelBuilder.Entity<UserStatus>().HasData(
                new { Id = 1, Name = "Pending" },
                new { Id = 2, Name = "Active" },
                new { Id = 3, Name = "Blocked" },
                new { Id = 4, Name = "Disabled" }
            );

            modelBuilder.Entity<ContactType>().HasData(
                new { Id = 1, Name = "Telefone" },
                new { Id = 2, Name = "Email" }
            );
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
