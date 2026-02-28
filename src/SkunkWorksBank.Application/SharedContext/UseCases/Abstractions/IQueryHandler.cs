using MediatR;
using SkunkWorksBank.Domain.Shared.Results;

namespace SkunkWorksBank.Application.SharedContext.UseCases.Abstractions
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
        where TResponse : IQueryResponse
    {
    }
}
