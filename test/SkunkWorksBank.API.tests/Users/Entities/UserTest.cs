using SkunkWorksBank.API.tests.Mocks;
using SkunkWorksBank.Domain.Users.Entities;

namespace SkunkWorksBank.API.tests.Users.Entities
{
    public class UserTest
    {
        private readonly FakeDateTimeProvider _dateTimeProvider = new FakeDateTimeProvider();

        [Fact]
        public void ShouldCreateAnUser()
        {
            var birthDate = new DateOnly(2000, 8, 18);
            var user = User.Create("12345678978", "Jãao Silva", _dateTimeProvider, birthDate, false);

            Assert.NotNull(user);
            Assert.Equal("12345678978", user.Cpf);
            Assert.Equal("Jãao Silva", user.FullName);
            Assert.Equal(_dateTimeProvider.UtcNow, user.Tracker.CreatedAt);
            Assert.Equal(_dateTimeProvider.UtcNow, user.Tracker.UpdatedAt);
            Assert.Equal(birthDate, user.Birthdate);
            Assert.False(user.IsPep);
        }
    }
}
