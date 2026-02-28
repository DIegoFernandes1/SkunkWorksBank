using SkunkWorksBank.Domain.Users.ValueObjects;

namespace SkunkWorksBank.API.tests.Users.ValueObjects
{
    public class NameTest
    {
        private const string _value = "Diego Fernandes de Meneses";
        private readonly Name _name = Name.Create("Diego Fernandes de Meneses").Value;

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
            var result = Name.Create(name);

            Assert.True(result.IsFailure);
            Assert.Equal("422", result.Error.Code);
            Assert.Equal("Nome não pode ser vazio.", result.Error.Message);
        }

        [Fact]
        public void ShouldFailIfNameLenghtIsNotValid()
        {
            var result = Name.Create("Die");

            Assert.True(result.IsFailure);
            Assert.Equal("422", result.Error.Code);
            Assert.Equal($"Nome deve ter no minimo {Name.MinLenght} caracteres.", result.Error.Message);
        }
    }
}
