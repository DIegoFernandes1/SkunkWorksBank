using SkunkWorksBank.Application.SharedContext.UseCases.Abstractions;

namespace SkunkWorksBank.Application.UserContext.UseCases.Get
{
    public record Query(Guid Id) : IQuery<Response>;
}
