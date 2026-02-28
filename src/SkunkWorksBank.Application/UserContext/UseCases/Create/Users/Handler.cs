using SkunkWorksBank.Domain.Shared.Results;
using SkunkWorksBank.Application.SharedContext.UseCases.Abstractions;
using SkunkWorksBank.Domain.Shared.Data.Abstractions;
using SkunkWorksBank.Domain.UserContext.Specifications;
using SkunkWorksBank.Domain.Users.Entities;
using SkunkWorksBank.Domain.Users.Repositories.Abstractions;

namespace SkunkWorksBank.Application.UserContext.UseCases.Create.Users
{
    public sealed class Handler(IUserRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<UserCommand, Response>
    {
        public async Task<Result<Response>> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            //verifica se já existe um usuario cadastrado
            var userExists = await userRepository.FindAsync(new GetByCpfSpecification(request.Cpf), cancellationToken);

            if (userExists is not null)
                return Result.Failure<Response>(new Error("400", "CPF Já cadastrado."));

            var user = await User.Create(request.Cpf, request.FullName, request.BirthDate, request.IsPep)
                .TapAsync(user => userRepository.AddAsync(user, cancellationToken))
                .TapAsync(_ => unitOfWork.CommitAsync(cancellationToken));

            return Result.Success(new Response(user.Value.Id));
        }
    }
}
