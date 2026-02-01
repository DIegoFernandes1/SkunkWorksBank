using Microsoft.EntityFrameworkCore;
using SkunkWorksBank.Domain.Shared.Specifications;
using SkunkWorksBank.Domain.Users.Entities;
using SkunkWorksBank.Domain.Users.Repositories.Abstractions;
using SkunkWorksBank.Repository.SharedContext.Data;

namespace SkunkWorksBank.Repository.UserContext.Repositories
{
    internal class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task AddAsync(User user, CancellationToken cancellationToken = default)
            => await context.Users.AddAsync(user, cancellationToken);

        public async Task<User?> FindAsync(ISpecification<User> specification, CancellationToken cancellationToken = default)
            => await context.Users
                .Include(x => x.UserStatus)
                .Include(x => x.Contacts).ThenInclude(x => x.ContactType)
                .Where(specification.Criteria)
                .FirstOrDefaultAsync(cancellationToken);
    }
}
