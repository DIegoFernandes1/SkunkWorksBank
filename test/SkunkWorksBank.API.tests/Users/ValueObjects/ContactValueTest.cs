using SkunkWorksBank.Domain.UserContext.ValueObjects;
using SkunkWorksBank.Domain.UserContext.ValueObjects.Exceptions;

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
            var contactValue = ContactValue.Create(value);

            Assert.Equal(contactValue, value);
        }

        [Theory]
        [InlineData("912345678")]
        [InlineData("(19) 234-5678")]
        [InlineData("email@email")]
        public void ShouldFailToCreateContactValue(string value)
        {
            Assert.Throws<InvalidUnknownContactTypeException>(() =>
            {
                ContactValue.Create(value);
            });
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldFailToCreateContactValueWithEmptyOrSpace(string value)
        {
            Assert.Throws<InvalidContactValueException>(() =>
            {
                ContactValue.Create(value);
            });
        }
    }
}
