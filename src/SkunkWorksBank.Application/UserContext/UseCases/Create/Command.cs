using SkunkWorksBank.Application.SharedContext.UseCases.Abstractions;

namespace SkunkWorksBank.Application.UserContext.UseCases.Create
{
    public sealed record Command(
        string Cpf,
        string FullName,
        DateOnly BirthDate,
        bool IsPep
        ) : ICommand<Response>;
}
