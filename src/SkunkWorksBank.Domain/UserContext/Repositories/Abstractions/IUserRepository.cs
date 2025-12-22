using SkunkWorksBank.Domain.Shared.Repositories.Abstractions;
using SkunkWorksBank.Domain.Users.Entities;

namespace SkunkWorksBank.Domain.Users.Repositories.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        Task SaveAsync(User user, CancellationToken cancellationToken = default);
        Task<bool> VerifyUserExistsAsync(string cpf, CancellationToken cancellationToken = default);
    }
}
