using SkunkWorksBank.Application.SharedContext.UseCases.Abstractions;

namespace SkunkWorksBank.Application.UserContext.UseCases.Create.Users
{
    public sealed record UserCommand(
        string Cpf,
        string FullName,
        DateOnly BirthDate,
        bool IsPep
        ) : ICommand<Response>;
}
