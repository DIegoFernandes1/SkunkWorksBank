using SkunkWorksBank.Domain.Shared.Results;
using SkunkWorksBank.Application.SharedContext.UseCases.Abstractions;
using SkunkWorksBank.Domain.Shared.Data.Abstractions;
using SkunkWorksBank.Domain.UserContext.Specifications;
using SkunkWorksBank.Domain.Users.Repositories.Abstractions;

namespace SkunkWorksBank.Application.UserContext.UseCases.Create.Contacts
{
    public sealed class Handler(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        : ICommandHandler<ContactCommand, Response>
    {
        public async Task<Result<Response>> Handle(ContactCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.FindAsync(new GetByIdSpecification(request.UserId), cancellationToken);

            if (user is null)
                return Result.Failure<Response>(new Error("404", $"Usuário não encontrado com o ID fornecido. ID {request.UserId}"));

            var result = await user
                .AddContact(request.ContactTypeId, request.Value, request.IsPrimary, request.IsVerified)
                .TapAsync(_ => unitOfWork.CommitAsync(cancellationToken));

            if(result.IsFailure)
                return Result.Failure<Response>(result.Error);

            return Result.Success(new Response(result.Value.Id));
        }
    }
}
