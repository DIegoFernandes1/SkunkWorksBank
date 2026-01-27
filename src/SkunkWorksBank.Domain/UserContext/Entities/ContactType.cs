using SkunkWorksBank.Domain.Shared.Entities;

namespace SkunkWorksBank.Domain.UserContext.Entities
{
    public sealed class ContactType : Entity<int>
    {
        #region Constructors
        private ContactType() : base(default) { }
        private ContactType(int id, string name) : base(id)
        {
            Name = name;
        }
        #endregion


        #region Properties
        public string Name { get; } = null!;
        #endregion
    }
}
