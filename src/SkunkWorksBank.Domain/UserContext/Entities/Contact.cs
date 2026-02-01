using SkunkWorksBank.Domain.Shared.Entities;
using SkunkWorksBank.Domain.UserContext.ValueObjects;
using SkunkWorksBank.Domain.Users.Entities;

namespace SkunkWorksBank.Domain.UserContext.Entities
{
    public sealed class Contact : Entity<int>
    {
        #region Constructors
        private Contact() : base(default!) { }
        private Contact(
            Guid userId,
            int contactTypeId,
            string value,
            bool isPrimary,
            bool isVerified)
        : base(default!)
        {
            UserId = userId;
            ContactTypeId = contactTypeId;
            Value = ContactValue.Create(value);
            IsPrimary = isPrimary;
            IsVerified = isVerified;
        }
        #endregion

        #region Properties
        public Guid UserId { get; }
        public User User { get; set; } = null!;

        public int ContactTypeId { get; }
        public ContactType ContactType { get; set; } = null!;

        public ContactValue Value { get; } = null!;
        public bool IsPrimary { get; }
        public bool IsVerified { get; }
        #endregion

        #region Factory
        public static Contact Create(Guid userId, int contactTypeId, string value, bool isPrimary, bool isVerified)
        {
            return new Contact(userId, contactTypeId, value, isPrimary, isVerified);
        }
        #endregion

    }
}
