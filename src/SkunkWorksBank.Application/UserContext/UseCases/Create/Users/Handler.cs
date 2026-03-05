using SkunkWorksBank.Domain.Shared.Results;
using SkunkWorksBank.Application.SharedContext.UseCases.Abstractions;
using SkunkWorksBank.Domain.Shared.Data.Abstractions;
using SkunkWorksBank.Domain.UserContext.Specifications;
using SkunkWorksBank.Domain.Users.Entities;
using SkunkWorksBank.Domain.Users.Repositories.Abstractions;
using SkunkWorksBank.Domain.Shared.Common;

namespace SkunkWorksBank.Application.UserContext.UseCases.Create.Users
{
    public sealed class Handler(IUserRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<UserCommand, Response>
    {
        public async Task<Result<Response>> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            //verifica se já existe um usuario cadastrado
            var userExists = await userRepository.FindAsync(new GetByCpfSpecification(request.Cpf), cancellationToken);

            if (userExists is not null)
                return Result.Failure<Response>(new Error(HttpCode.BAD_REQUEST_400, "CPF Já cadastrado."));

            var result = await User.Create(request.Cpf, request.FullName, request.BirthDate, request.IsPep)
                .TapAsync(user => userRepository.AddAsync(user, cancellationToken))
                .TapAsync(_ => unitOfWork.CommitAsync(cancellationToken));

            if(result.IsFailure)
                return Result.Failure<Response>(result.Error);

            return Result.Success(new Response(result.Value.Id));
        }
    }
}
