using SkunkWorksBank.Domain.UserContext.Entities;

namespace SkunkWorksBank.API.tests.Users.Entities
{
    public class ContactTest
    {
        [Fact]
        public void ShouldCreateAContactWithEmail()
        {
            var contact = Contact.Create(new Guid(), 1, "email@email.com", true, true);

            Assert.Equal("email@email.com", contact.Value.Value);
        }

        [Fact]
        public void ShouldCreateAContactWithTelephone()
        {
            var contact = Contact.Create(new Guid(), 1, "19912345678", true, true);

            Assert.Equal("19912345678", contact.Value.Value);
        }
    }
}
