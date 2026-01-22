using SkunkWorksBank.Application.SharedContext.UseCases.Abstractions;

namespace SkunkWorksBank.Application.UserContext.UseCases.Get
{
    public record Response(
        Guid Id,
        string Cpf,
        string FullName,
        bool IsActive,
        DateOnly Birthdate,
        bool IsPep,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        UserStatusResponse UserStatus
        ) : IQueryResponse;

    //records de apoio
    public record UserStatusResponse(int Id, string Name);
}
