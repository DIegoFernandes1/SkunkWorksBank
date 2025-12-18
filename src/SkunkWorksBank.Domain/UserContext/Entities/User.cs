using SkunkWorksBank.Domain.Shared.Abstractions;
using SkunkWorksBank.Domain.Shared.Aggregates.Abstractions;
using SkunkWorksBank.Domain.Shared.Entities;
using SkunkWorksBank.Domain.Users.Enums;
using SkunkWorksBank.Domain.Users.ValueObjects;

namespace SkunkWorksBank.Domain.Users.Entities
{
    public sealed class User : Entity, IAggregateRoot
    {
        #region Constructors
        private User(
            UserStatus userStatus,
            string cpf,
            string fullName,
            bool isActive,
            IDateTimeProvider dateTimeProvider,
            DateOnly birthDate,
            bool isPep)
        : base(Guid.CreateVersion7())
        {
            UserStatus = userStatus;
            Cpf = Cpf.Create(cpf);
            FullName = Name.Create(fullName);
            IsActive = isActive;
            Tracker = Tracker.Create(dateTimeProvider);
            Birthdate = BirthDate.Create(birthDate, DateOnly.FromDateTime(dateTimeProvider.UtcNow));
            IsPep = isPep;
        }
        #endregion

        #region Properties
        public UserStatus UserStatus { get; }
        public Cpf Cpf { get; }
        public Name FullName { get; }
        public bool IsActive { get; }
        public Tracker Tracker { get; }
        public BirthDate Birthdate { get; }
        public bool IsPep { get; }
        #endregion

        #region Factories
        public static User Create(string cpf, string fullName, IDateTimeProvider dateTimeProvider, DateOnly birthDate, bool isPep)
        {
            return new User(UserStatus.Pending, cpf, fullName, false, dateTimeProvider, birthDate, isPep);
        }
        #endregion
    }
}
