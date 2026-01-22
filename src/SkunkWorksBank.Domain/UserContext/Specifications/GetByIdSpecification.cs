using SkunkWorksBank.Domain.Shared.Specifications;
using SkunkWorksBank.Domain.Users.Entities;
using System.Linq.Expressions;

namespace SkunkWorksBank.Domain.UserContext.Specifications
{
    public class GetByIdSpecification(Guid id) : ISpecification<User>
    {
        public Expression<Func<User, bool>> Criteria
           => x => x.Id == id;

        public bool IsSatisfiedBy(User entity)
            => entity.Id == id;
    }
}
