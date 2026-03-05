using SkunkWorksBank.Domain.Shared.Common;
using SkunkWorksBank.Domain.Shared.Results;
using SkunkWorksBank.Domain.Shared.ValueObjects;

namespace SkunkWorksBank.Domain.Users.ValueObjects
{
    public sealed record BirthDate : ValueObject
    {
        #region Constants
        public const int MaxAge = 120;
        public const int MinAge = 16;
        #endregion

        #region Properties
        public DateOnly Date { get; }
        #endregion

        #region Constructors

        private BirthDate()
        {

        }
        private BirthDate(DateOnly date)
        {
            Date = date;
        }
        #endregion

        #region Factories
        public static Result<BirthDate> Create(DateOnly date, DateOnly today)
        {
            if (date > today)
                return Result.Failure<BirthDate>(new Error(HttpCode.UNPROCESSABLE_CONTENT_422, Message.FUTURE_DATE));

            var age = GetAge(date, today);

            if (age > MaxAge)
                return Result.Failure<BirthDate>(new Error(HttpCode.UNPROCESSABLE_CONTENT_422, Message.MAX_DATE));

            if (age < MinAge)
                return Result.Failure<BirthDate>(new Error(HttpCode.UNPROCESSABLE_CONTENT_422, Message.MIN_DATE));

            return Result.Success(new BirthDate(date));
        }
        #endregion

        #region Methods
        private static int GetAge(DateOnly birthDate, DateOnly today)
        {
            var age = today.Year - birthDate.Year;

            if (today < birthDate.AddYears(age))
                age--;

            return age;
        }

        public int GetAge(DateOnly today)
        {
            return GetAge(Date, today);
        }
        #endregion

        #region Operators
        public static implicit operator DateOnly(BirthDate birthDate) => birthDate.Date;
        #endregion
    }
}
