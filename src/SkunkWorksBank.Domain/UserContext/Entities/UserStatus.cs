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

        public static readonly UserStatus Pending = new(1, "Pending");
        public static readonly UserStatus Active = new(2, "Active");
        public static readonly UserStatus Blocked = new(3, "Blocked");
        public static readonly UserStatus Disabled = new(4, "Disabled");
    }
}
