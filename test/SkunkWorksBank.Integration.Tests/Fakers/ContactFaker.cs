using Bogus;
using SkunkWorksBank.Application.UserContext.UseCases.Create.Contacts;

namespace SkunkWorksBank.API.Integration.Tests.Fakers
{
    public class ContactFaker
    {
        public static Faker<ContactCommand> CreateContactCommand(Guid userId, bool invalidValue = false, bool whiteSpace = false) =>
        new Faker<ContactCommand>("pt_BR")
            .CustomInstantiator(f => new ContactCommand(
                UserId: userId,
                ContactTypeId: 1,
                Value: invalidValue 
                ? whiteSpace 
                    ? "" 
                    : "123" 
                : f.Phone.PhoneNumber("199########"),
                IsPrimary: f.Random.Bool(),
                IsVerified: f.Random.Bool()
            ));
    }
}
