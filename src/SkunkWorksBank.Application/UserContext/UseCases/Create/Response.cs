using SkunkWorksBank.Application.SharedContext.UseCases.Abstractions;

namespace SkunkWorksBank.Application.UserContext.UseCases.Create
{
    public sealed record Response(Guid id) : ICommandResponse;
}
