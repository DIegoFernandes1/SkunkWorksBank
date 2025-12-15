using SkunkWorksBank.Domain.Users.ValueObjects;
using SkunkWorksBank.Domain.Users.ValueObjects.Exceptions;

namespace SkunkWorksBank.API.tests.Users.ValueObjects
{
    public class NameTest
    {
        private const string _value = "Diego Fernandes de Meneses";
        private readonly Name _name = Name.Create("Diego Fernandes de Meneses");

        [Fact]
        public void ShouldCreateAName()
        {
            var data = _name;
            Assert.Equal(data, _name);
        }

        [Fact]
        public void ShouldOverrideToStringMethod()
        {
            Assert.Equal(_value, _name.ToString());
        }

        [Fact]
        public void ShouldImplicitConvertToString()
        {
            var data = _name;
            Assert.Equal(data, _name.ToString());
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldFailIfNameIsNotValid(string name)
        {

            Assert.Throws<InvalidNameExpection>(() =>
            {
                Name.Create(name);
            });
        }

        [Fact]
        public void ShouldFailIfNameLenghtIsNotValid()
        {

            Assert.Throws<InvalidNameLenghtException>(() =>
            {
                Name.Create("Die");
            });
        }
    }
}
