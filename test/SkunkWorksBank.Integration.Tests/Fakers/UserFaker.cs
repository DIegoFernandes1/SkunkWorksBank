using Bogus;
using Bogus.Extensions.Brazil;
using SkunkWorksBank.Application.UserContext.UseCases.Create.Users;

namespace SkunkWorksBank.API.Integration.Tests.Fakers
{
    public static class UserFaker
    {
        public static Faker<UserCommand> CreateUserCommand(bool invalidBirthDate = false, bool invalidCpf = false, bool invalidFullName = false) =>
        new Faker<UserCommand>("pt_BR")
            .CustomInstantiator(f => new UserCommand(
                FullName: invalidFullName ? "Di" : f.Name.FullName(),
                Cpf: invalidCpf ? "00145" : f.Person.Cpf(false),
                BirthDate: invalidBirthDate ? new DateOnly(2022, 5, 12) : DateOnly.FromDateTime(f.Person.DateOfBirth),
                IsPep: f.Random.Bool()
            ));
    }
}
