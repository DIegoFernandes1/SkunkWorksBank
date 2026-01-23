using SkunkWorksBank.Application.SharedContext.UseCases.Abstractions;

namespace SkunkWorksBank.Application.UserContext.UseCases.Get.ById
{
    public record Query(Guid Id) : IQuery<Response>;
}
