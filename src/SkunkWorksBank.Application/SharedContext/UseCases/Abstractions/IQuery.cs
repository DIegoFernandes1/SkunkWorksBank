using MediatR;
using SkunkWorksBank.Application.SharedContext.Results;

namespace SkunkWorksBank.Application.SharedContext.UseCases.Abstractions
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>> where TResponse : IQueryResponse;
}
