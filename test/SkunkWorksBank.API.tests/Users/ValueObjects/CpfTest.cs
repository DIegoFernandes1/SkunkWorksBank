using SkunkWorksBank.Domain.Users.ValueObjects;
using SkunkWorksBank.Domain.Users.ValueObjects.Exceptions;

namespace SkunkWorksBank.API.tests.Users.ValueObjects
{
    public class CpfTest
    {

        private readonly string _value = "12345678989";
        private readonly Cpf _cpf = Cpf.Create("12345678989");

        [Fact]
        public void ShouldCreateNewCpf()
        {
            var cpf = Cpf.Create(_value);
            Assert.Equal(cpf, cpf.ToString());
        }

        [Fact]
        public void ShouldOverrideToStringMethod()
        {
            Assert.Equal(_value, _cpf.ToString());
        }

        [Fact]
        public void ShouldImplicitConvertToString()
        {
            var data = _cpf;
            Assert.Equal(data, _cpf.ToString());
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void ShouldFailToCreateACpfIfIsNotValid(string value)
        {
            Assert.Throws<InvalidCpfException>(() =>
            {
                var cpf = Cpf.Create(value);
            });
        }

        [Theory]
        [InlineData("123456")]
        [InlineData("12345678987878")]
        public void ShouldFailToCreateACpfLenghtIfIsNotValid(string value)
        {
            Assert.Throws<InvalidCpfLenghtException>(() =>
            {
                var cpf = Cpf.Create(value);
            });
        }
    }
}
