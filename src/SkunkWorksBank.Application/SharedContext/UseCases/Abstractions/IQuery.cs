using MediatR;
using SkunkWorksBank.Domain.Shared.Results;

namespace SkunkWorksBank.Application.SharedContext.UseCases.Abstractions
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>> where TResponse : IQueryResponse;
}
