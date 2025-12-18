using SkunkWorksBank.Domain.Users.Entities;
using SkunkWorksBank.Domain.Users.Repositories.Abstractions;
using SkunkWorksBank.Repository.SharedContext.Data;

namespace SkunkWorksBank.Repository.UserContext.Repositories
{
    internal class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task SaveAsync(User user, CancellationToken cancellationToken = default)
        => await context.AddAsync(user, cancellationToken);
    }
}
