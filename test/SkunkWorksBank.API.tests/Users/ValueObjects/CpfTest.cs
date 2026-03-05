using SkunkWorksBank.Domain.Shared.Common;
using SkunkWorksBank.Domain.Users.ValueObjects;

namespace SkunkWorksBank.API.tests.Users.ValueObjects
{
    public class CpfTest
    {

        private readonly string _value = "12345678989";
        private readonly Cpf _cpf = Cpf.Create("12345678989").Value;

        [Fact]
        public void ShouldCreateNewCpf()
        {
            var result = Cpf.Create(_value);
            Assert.Equal(result.Value.Value, _value);
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
            var result = Cpf.Create(value);

            Assert.True(result.IsFailure);
            Assert.Equal(HttpCode.UNPROCESSABLE_CONTENT_422, result.Error.Code);
            Assert.Equal(Message.CPF_EMPTY_OR_NULL, result.Error.Message);
        }

        [Theory]
        [InlineData("123456")]
        [InlineData("12345678987878")]
        public void ShouldFailToCreateACpfLenghtIfIsNotValid(string value)
        {
            var result = Cpf.Create(value);

            Assert.True(result.IsFailure);
            Assert.Equal(HttpCode.UNPROCESSABLE_CONTENT_422, result.Error.Code);
            Assert.Equal(Message.CPF_MAX_LENGHT, result.Error.Message);
        }
    }
}
