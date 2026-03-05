using SkunkWorksBank.Domain.Shared.Common;
using SkunkWorksBank.Domain.Users.ValueObjects;

namespace SkunkWorksBank.API.tests.Users.ValueObjects
{
    public class BirthDateTest
    {
        DateOnly _today = DateOnly.FromDateTime(DateTime.Today);
        DateOnly _BornDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30));

        [Fact]
        public void ShouldCreateAValidBirthdate()
        {
            var result = BirthDate.Create(_BornDate, _today);
            Assert.Equal(result.Value.Date, _BornDate);
        }

        [Fact]
        public void ShouldNotCreateABirthdate()
        {
            var result = BirthDate.Create(_today, _today);

            Assert.True(result.IsFailure);
            Assert.Equal(HttpCode.UNPROCESSABLE_CONTENT_422, result.Error.Code);
            Assert.Equal(Message.MIN_DATE, result.Error.Message);
        }

        [Fact]
        public void ShouldNotCreateABirthdateWithDataForTomorrow()
        {
            var tomorrow = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

            var result = BirthDate.Create(tomorrow, _today);

            Assert.True(result.IsFailure);
            Assert.Equal(HttpCode.UNPROCESSABLE_CONTENT_422, result.Error.Code);
            Assert.Equal(Message.FUTURE_DATE, result.Error.Message);
        }

        [Fact]
        public void ShouldNotCreateABirthdateWithMaxDate()
        {
            var maxDate = DateOnly.FromDateTime(DateTime.Today.AddYears(BirthDate.MaxAge));

            var result = BirthDate.Create(maxDate, _today);

            Assert.True(result.IsFailure);
            Assert.Equal(HttpCode.UNPROCESSABLE_CONTENT_422, result.Error.Code);
            Assert.Equal(Message.FUTURE_DATE, result.Error.Message);
        }

        [Fact]
        public void ShouldCreateABirthdateWithExactMaxDate()
        {
            var maxDate = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-BirthDate.MaxAge));
            var result = BirthDate.Create(maxDate, _today);

            Assert.Equal(result.Value.Date, maxDate);
        }

        [Fact]
        public void ShouldNotCreateABirthdateWitMaxDatePlusOne()
        {
            var maxDate = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-(BirthDate.MaxAge + 1)));

            var result = BirthDate.Create(maxDate, _today);

            Assert.True(result.IsFailure);
            Assert.Equal(HttpCode.UNPROCESSABLE_CONTENT_422, result.Error.Code);
            Assert.Equal(Message.MAX_DATE, result.Error.Message);
        }

        [Fact]
        public void ShouldCreateABiSextoValidBirthdate()
        {
            var date = DateOnly.FromDateTime(new DateTime(2000, 2, 29));
            var result = BirthDate.Create(date, _today);
            Assert.Equal(result.Value.Date, date);
        }
    }
}
