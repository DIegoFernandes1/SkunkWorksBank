using SkunkWorksBank.Domain.Shared.Abstractions;
using SkunkWorksBank.Domain.Shared.Aggregates.Abstractions;
using SkunkWorksBank.Domain.Shared.Common;
using SkunkWorksBank.Domain.Shared.Entities;
using SkunkWorksBank.Domain.UserContext.Entities;
using SkunkWorksBank.Domain.UserContext.Enums;
using SkunkWorksBank.Domain.Users.ValueObjects;

namespace SkunkWorksBank.Domain.Users.Entities
{
    public sealed class User : Entity<Guid>, IAggregateRoot
    {
        #region Constants
        private int _userStatusId;
        #endregion

        #region Constructors

        private User() : base(default!) { }

        private User(
            int UserStatusId,
            string cpf,
            string fullName,
            bool isActive,
            IDateTimeProvider dateTimeProvider,
            DateOnly birthDate,
            bool isPep)
        : base(Guid.CreateVersion7())
        {
            _userStatusId = UserStatusId;
            Cpf = Cpf.Create(cpf);
            FullName = Name.Create(fullName);
            IsActive = isActive;
            Tracker = Tracker.Create(dateTimeProvider);
            Birthdate = BirthDate.Create(birthDate, DateOnly.FromDateTime(dateTimeProvider.UtcNow));
            IsPep = isPep;
        }
        #endregion

        #region Properties
        public UserStatus UserStatus { get; } = null!;
        public Cpf Cpf { get; } = null!;
        public Name FullName { get; } = null!;
        public bool IsActive { get; }
        public Tracker Tracker { get; } = null!;
        public BirthDate Birthdate { get; } = null!;
        public bool IsPep { get; }
        #endregion

        #region Factories
        public static User Create(string cpf, string fullName, DateOnly birthDate, bool isPep)
        {
            return new User((int)UserStatusId.Pending, cpf, fullName, false, new DateTimeProvider(), birthDate, isPep);
        }
        #endregion
    }
}
