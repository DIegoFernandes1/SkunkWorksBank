using SkunkWorksBank.Domain.Users.Entities;

namespace SkunkWorksBank.API.tests.Users.Entities
{
    public class UserTest
    {
        [Fact]
        public void ShouldCreateAnUser()
        {
            var birthDate = new DateOnly(2000, 8, 18);
            var result = User.Create("12345678978", "Jãao Silva", birthDate, false);

            Assert.True(result.IsSuccess);
            Assert.Equal("12345678978", result.Value.Cpf);
            Assert.Equal("Jãao Silva", result.Value.FullName);
            Assert.Equal(birthDate, result.Value.Birthdate);
            Assert.False(result.Value.IsPep);
        }
    }
}
