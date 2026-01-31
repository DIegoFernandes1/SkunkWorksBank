using SkunkWorksBank.Application.SharedContext.UseCases.Abstractions;

namespace SkunkWorksBank.Application.UserContext.UseCases.Create.Users
{
    public sealed record Response(Guid id) : ICommandResponse;
}
