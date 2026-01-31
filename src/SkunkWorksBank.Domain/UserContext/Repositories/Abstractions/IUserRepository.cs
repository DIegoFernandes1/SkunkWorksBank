using SkunkWorksBank.Domain.Shared.Repositories.Abstractions;
using SkunkWorksBank.Domain.Shared.Specifications;
using SkunkWorksBank.Domain.Users.Entities;

namespace SkunkWorksBank.Domain.Users.Repositories.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        Task AddAsync(User user, CancellationToken cancellationToken = default);
        Task<User?> FindAsync(ISpecification<User> specification, CancellationToken cancellationToken = default);
    }
}
