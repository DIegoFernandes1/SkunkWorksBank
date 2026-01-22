using SkunkWorksBank.Domain.Shared.Specifications;
using SkunkWorksBank.Domain.Users.Entities;
using System.Linq.Expressions;

namespace SkunkWorksBank.Domain.UserContext.Specifications
{
    public class GetByCpfSpecification(string cpf) : ISpecification<User>
    {
        public Expression<Func<User, bool>> Criteria
            => x => x.Cpf.Value == cpf;

        public bool IsSatisfiedBy(User entity)
            => entity.Cpf.Value == cpf;
    }
}
