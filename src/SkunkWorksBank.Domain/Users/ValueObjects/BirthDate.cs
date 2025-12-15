using SkunkWorksBank.Domain.Shared.ValueObjects;
using SkunkWorksBank.Domain.Users.ValueObjects.Exceptions;

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
        public BirthDate(DateOnly date)
        {
            Date = date;
        }
        #endregion

        #region Factories
        public static BirthDate Create(DateOnly date, DateOnly today)
        {
            if (date > today)
                throw new InvalidBirthDateException("Idade não pode ser futura");

            var age = GetAge(date, today);

            if (age > MaxAge)
                throw new InvalidBirthDateException($"Idade máxima é de {MaxAge} anos.");

            if (age < MinAge)
                throw new InvalidBirthDateException($"Idade minima é de {MinAge} anos.");

            return new BirthDate(date);
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
