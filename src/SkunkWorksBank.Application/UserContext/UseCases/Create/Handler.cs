using SkunkWorksBank.Application.SharedContext.Results;
using SkunkWorksBank.Application.SharedContext.UseCases.Abstractions;
using SkunkWorksBank.Domain.Shared.Data.Abstractions;
using SkunkWorksBank.Domain.Users.Entities;
using SkunkWorksBank.Domain.Users.Repositories.Abstractions;

namespace SkunkWorksBank.Application.UserContext.UseCases.Create
{
    public sealed class Handler(IUserRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<Command, Response>
    {
        public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
        {
            //verifica se já existe um usuario cadastrado
            var userExists = await userRepository.VerifyUserExistsAsync(request.Cpf, cancellationToken);

            if (userExists)
                return Result.Failure<Response>(new Error("400", "CPF Já cadastrado."));

            var user = User.Create(request.Cpf, request.FullName, request.BirthDate, request.IsPep);

            await userRepository.SaveAsync(user, cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            return Result.Success(new Response(user.Id));
        }
    }
}
