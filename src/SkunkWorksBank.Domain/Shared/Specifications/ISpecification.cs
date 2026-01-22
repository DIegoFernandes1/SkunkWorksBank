using System.Linq.Expressions;

namespace SkunkWorksBank.Domain.Shared.Specifications
{
    public interface ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }
        bool IsSatisfiedBy(T entity);
    }
}
