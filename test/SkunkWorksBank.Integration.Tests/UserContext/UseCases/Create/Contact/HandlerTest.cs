using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SkunkWorksBank.API.Integration.Tests.Fakers;
using SkunkWorksBank.Application.SharedContext.Behavios;
using SkunkWorksBank.Application.UserContext.UseCases.Create.Users;
using SkunkWorksBank.Domain.Shared.Results;

namespace SkunkWorksBank.API.Integration.Tests.UserContext.UseCases.Create.Contact
{
    public class HandlerTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly IServiceScope _scope;
        private readonly ISender _sender;

        public HandlerTest(CustomWebApplicationFactory factory)
        {
            _scope = factory.Services.CreateScope();
            _sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        }

        private async Task<Result<Response>> CreateUser()
        {
            var command = UserFaker.CreateUserCommand().Generate();
            return await _sender.Send(command, CancellationToken.None);
        }

        [Fact]
        public async Task ShouldCreateAContact()
        {
            var resultUser = await CreateUser();
            Assert.True(resultUser.IsSuccess);

            var contactCommand = ContactFaker.CreateContactCommand(resultUser.Value.id).Generate();
            var resultContact = await _sender.Send(contactCommand, CancellationToken.None);

            Assert.True(resultContact.IsSuccess);
            Assert.NotNull(resultContact.Value);
        }

        [Fact]
        public async void ShouldFailToCreateAContactWithBlankValue()
        {
            var resultUser = await CreateUser();
            Assert.True(resultUser.IsSuccess);

            var contactCommand = ContactFaker.CreateContactCommand(resultUser.Value.id, true, true).Generate();

            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await _sender.Send(contactCommand, CancellationToken.None);
            });
        }

        [Fact]
        public async void ShouldFailToCreateAContactWithInvalidValue()
        {
            var resultUser = await CreateUser();
            Assert.True(resultUser.IsSuccess);

            var contactCommand = ContactFaker.CreateContactCommand(resultUser.Value.id, true).Generate();
            var resultContact = await _sender.Send(contactCommand, CancellationToken.None);

            Assert.True(resultContact.IsFailure);
            Assert.Equal("422", resultContact.Error.Code);
            Assert.Equal("É necessário informar um contato válido.", resultContact.Error.Message);
        }
    }
}
