using SkunkWorksBank.Domain.Shared.Abstractions;
using SkunkWorksBank.Domain.Shared.Results;
using SkunkWorksBank.Domain.Shared.ValueObjects;

namespace SkunkWorksBank.Domain.Users.ValueObjects
{
    public sealed record Tracker : ValueObject
    {
        #region Properties

        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; private set; }

        #endregion

        #region Constructos
        private Tracker()
        {

        }
        private Tracker(DateTime createdAt, DateTime updatedAt)
        {
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        #endregion

        #region Factories
        public static Result<Tracker> Create(IDateTimeProvider dateTimeProvider)
            => Result.Success(new Tracker(dateTimeProvider.UtcNow, dateTimeProvider.UtcNow));

        public static Result<Tracker> Create(DateTime createdAt, DateTime updatedAt)
           => Result.Success(new Tracker(createdAt, updatedAt));
        #endregion

        #region Methods
        public void Update(IDateTimeProvider dateTimeProvider)
        {
            UpdatedAt = dateTimeProvider.UtcNow;
        }
        #endregion
    }
}
