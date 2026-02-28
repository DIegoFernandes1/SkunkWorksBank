using SkunkWorksBank.Domain.Shared.Abstractions;
using SkunkWorksBank.Domain.Shared.Aggregates.Abstractions;
using SkunkWorksBank.Domain.Shared.Common;
using SkunkWorksBank.Domain.Shared.Entities;
using SkunkWorksBank.Domain.Shared.Results;
using SkunkWorksBank.Domain.UserContext.Entities;
using SkunkWorksBank.Domain.UserContext.Enums;
using SkunkWorksBank.Domain.Users.ValueObjects;

namespace SkunkWorksBank.Domain.Users.Entities
{
    public sealed class User : Entity<Guid>, IAggregateRoot
    {
        #region Constants
        private int _userStatusId;
        private readonly List<Contact> _contacts = new();
        #endregion

        #region Constructors

        private User() : base(default!) { }

        private User(
            int UserStatusId,
            Cpf cpf,
            Name fullName,
            bool isActive,
            Tracker tracker,
            BirthDate birthDate,
            bool isPep)
        : base(Guid.CreateVersion7())
        {
            _userStatusId = UserStatusId;
            Cpf = cpf;
            FullName = fullName;
            IsActive = isActive;
            Tracker = tracker;
            Birthdate = birthDate;
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
        public IReadOnlyCollection<Contact> Contacts => _contacts.AsReadOnly();
        #endregion

        #region Factories
        public static Result<User> Create(string cpf, string fullName, DateOnly birthDate, bool isPep)
        {
            var dateTimeProvider = new DateTimeProvider();

            var cpfResult = Cpf.Create(cpf);
            var nameResult = Name.Create(fullName);
            var trackerResult = Tracker.Create(dateTimeProvider);
            var birthDateResult = BirthDate.Create(birthDate, DateOnly.FromDateTime(dateTimeProvider.UtcNow));

            var validationResult = Result.Combine(cpfResult, nameResult, trackerResult, birthDateResult);

            if (validationResult.IsFailure)
                return Result.Failure<User>(validationResult.Error);

            return Result.Success(new User((int)UserStatusId.Pending, cpfResult.Value, nameResult.Value, false, trackerResult.Value, birthDateResult.Value, isPep));
        }

        public Result<Contact> AddContact(int contactTypeId, string value, bool isPrimary, bool isVerified)
        {
            var exists = _contacts.Any(x => x.Value.Equals(value));

            if (exists)
                return Result.Failure<Contact>(new Error("409", "Já existe um contato cadastrado"));

            return Contact.Create(this.Id, contactTypeId, value, isPrimary, isVerified)
                .Tap(_contacts.Add);
        }
        #endregion
    }
}
