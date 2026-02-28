using SkunkWorksBank.Application.SharedContext.UseCases.Abstractions;

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
