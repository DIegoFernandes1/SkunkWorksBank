using SkunkWorksBank.Application.SharedContext.UseCases.Abstractions;
using SkunkWorksBank.Application.UserContext.UseCases.Create.Users;

namespace SkunkWorksBank.Application.UserContext.UseCases.Create.Contacts
{
    public sealed record ContactCommand(
        Guid UserId,
        int ContactTypeId,
        string Value,
        bool IsPrimary,
        bool IsVerified
        ) : ICommand<Response>;
}
