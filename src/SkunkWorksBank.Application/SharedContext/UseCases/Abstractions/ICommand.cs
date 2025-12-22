using MediatR;
using SkunkWorksBank.Application.SharedContext.Results;

namespace SkunkWorksBank.Application.SharedContext.UseCases.Abstractions
{
    public interface ICommand : IRequest<Result>;
    public interface ICommand<TCommandResponse> : IRequest<Result<TCommandResponse>> where TCommandResponse : ICommandResponse;
}
