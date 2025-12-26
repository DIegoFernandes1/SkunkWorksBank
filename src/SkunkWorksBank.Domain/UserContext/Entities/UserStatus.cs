using SkunkWorksBank.Domain.Shared.Entities;

namespace SkunkWorksBank.Domain.UserContext.Entities
{
    public sealed class UserStatus : Entity<int>
    {
        public UserStatus() : base(default) { }
        private UserStatus(int id, string name) : base(id)
        {
            Name = name;
        }

        #region Properties
        public string Name { get; } = null!;
        #endregion
    }
}
