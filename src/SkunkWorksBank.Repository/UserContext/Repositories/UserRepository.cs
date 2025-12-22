using Microsoft.EntityFrameworkCore;
using SkunkWorksBank.Domain.Users.Entities;
using SkunkWorksBank.Domain.Users.Repositories.Abstractions;
using SkunkWorksBank.Repository.SharedContext.Data;

namespace SkunkWorksBank.Repository.UserContext.Repositories
{
    internal class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task SaveAsync(User user, CancellationToken cancellationToken = default)
        => await context.Users.AddAsync(user, cancellationToken);

        public async Task<bool> VerifyUserExistsAsync(string cpf, CancellationToken cancellationToken = default)
            => await context.Users.AsNoTracking().AnyAsync(u => u.Cpf == cpf, cancellationToken);
    }
}
