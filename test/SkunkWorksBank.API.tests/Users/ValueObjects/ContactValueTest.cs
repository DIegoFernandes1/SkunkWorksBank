using SkunkWorksBank.Domain.Shared.Common;
using SkunkWorksBank.Domain.UserContext.ValueObjects;

namespace SkunkWorksBank.API.tests.Users.ValueObjects
{
    public class ContactValueTest
    {
        [Theory]
        [InlineData("19912345678")]
        [InlineData("(19) 91234-5678")] //telefone
        [InlineData("(19) 1234-5678")] //fixo
        [InlineData("email@email.com")]
        public void ShouldCreateContactValue(string value)
        {
            var result = ContactValue.Create(value);

            Assert.Equal(result.Value.Value, value);
        }

        [Theory]
        [InlineData("912345678")]
        [InlineData("(19) 234-5678")]
        [InlineData("email@email")]
        public void ShouldFailToCreateContactValue(string value)
        {
            var result = ContactValue.Create(value);

            Assert.False(result.IsSuccess);
            Assert.Equal(HttpCode.UNPROCESSABLE_CONTENT_422, result.Error.Code);
            Assert.Equal(Message.INVALID_CONTACT, result.Error.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldFailToCreateContactValueWithEmptyOrSpace(string value)
        {
            var result = ContactValue.Create(value);

            Assert.False(result.IsSuccess);
            Assert.Equal(HttpCode.UNPROCESSABLE_CONTENT_422, result.Error.Code);
            Assert.Equal(Message.FIELD_EMPTY_OR_NULL, result.Error.Message);
        }
    }
}
