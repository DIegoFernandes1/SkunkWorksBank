using SkunkWorksBank.Domain.Users.ValueObjects;
using SkunkWorksBank.Domain.Users.ValueObjects.Exceptions;

namespace SkunkWorksBank.API.tests.Users.ValueObjects
{
    public class BirthDateTest
    {
        DateOnly _today = DateOnly.FromDateTime(DateTime.Today);
        DateOnly _BornDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30));

        [Fact]
        public void ShouldCreateAValidBirthdate()
        {
            var birthDate = BirthDate.Create(_BornDate, _today);
            Assert.Equal(birthDate.Date, _BornDate);
        }

        [Fact]
        public void ShouldNotCreateABirthdate()
        {
            Assert.Throws<InvalidBirthDateException>(() =>
            {
                BirthDate.Create(_today, _today);
            });
        }

        [Fact]
        public void ShouldNotCreateABirthdateWithDataForTomorrow()
        {
            var tomorrow = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

            Assert.Throws<InvalidBirthDateException>(() =>
            {
                BirthDate.Create(tomorrow, _today);
            });
        }

        [Fact]
        public void ShouldNotCreateABirthdateWithMaxDate()
        {
            var maxDate = DateOnly.FromDateTime(DateTime.Today.AddYears(BirthDate.MaxAge));

            Assert.Throws<InvalidBirthDateException>(() =>
            {
                BirthDate.Create(maxDate, _today);
            });
        }

        [Fact]
        public void ShouldCreateABirthdateWithExactMaxDate()
        {
            var maxDate = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-BirthDate.MaxAge));
            var birthDate = BirthDate.Create(maxDate, _today);

            Assert.Equal(birthDate.Date, maxDate);
        }

        [Fact]
        public void ShouldNotCreateABirthdateWitMaxDatePlusOne()
        {
            var maxDate = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-(BirthDate.MaxAge + 1)));

            Assert.Throws<InvalidBirthDateException>(() =>
            {
                BirthDate.Create(maxDate, _today);
            });
        }

        [Fact]
        public void ShouldCreateABiSextoValidBirthdate()
        {
            var date = DateOnly.FromDateTime(new DateTime(2000, 2, 29));
            var birthDate = BirthDate.Create(date, _today);
            Assert.Equal(birthDate.Date, date);
        }
    }
}
