using SkunkWorksBank.Domain.Shared.Aggregates.Abstractions;

namespace SkunkWorksBank.Domain.Shared.Repositories.Abstractions
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot;
}
