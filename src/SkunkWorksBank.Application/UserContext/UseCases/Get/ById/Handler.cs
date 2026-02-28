using SkunkWorksBank.Domain.Shared.Results;
using SkunkWorksBank.Application.SharedContext.UseCases.Abstractions;
using SkunkWorksBank.Domain.UserContext.Specifications;
using SkunkWorksBank.Domain.Users.Repositories.Abstractions;

namespace SkunkWorksBank.Application.UserContext.UseCases.Get.ById
{
    public class Handler(IUserRepository userRepository) : IQueryHandler<Query, Response>
    {
        public async Task<Result<Response>> Handle(Query request, CancellationToken cancellationToken)
        {
            var user = await userRepository.FindAsync(new GetByIdSpecification(request.Id), cancellationToken);

            if (user == null)
                return Result.Failure<Response>(new Error("404", "Usuário não encontrado"));

            return Result.Success(Response.FromEntity(user));
        }
    }
}
