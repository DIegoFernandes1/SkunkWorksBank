using SkunkWorksBank.Application.SharedContext.UseCases.Abstractions;

namespace SkunkWorksBank.Application.UserContext.UseCases.Create.Contacts
{
    public sealed record Response(int id) : ICommandResponse;
}
