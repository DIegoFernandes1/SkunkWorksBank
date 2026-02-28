using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SkunkWorksBank.API.Integration.Tests.Fakers;
using SkunkWorksBank.Application.SharedContext.Behavios;
using SkunkWorksBank.Domain.Users.ValueObjects;

namespace SkunkWorksBank.API.Integration.Tests.UserContext.UseCases.Create.User
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

        [Fact]
        public async Task ShouldCreateAnUser()
        {
            var command = UserFaker.CreateUserCommand().Generate();

            var result = await _sender.Send(command, CancellationToken.None);

            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
        }

        [Fact]
        public async void ShouldFailToCreateAnUserWithInvalidBirthDate()
        {
            var command = UserFaker.CreateUserCommand(true).Generate();

            var result = await _sender.Send(command, CancellationToken.None);

            Assert.True(result.IsFailure);
            Assert.Equal("422", result.Error.Code);
            Assert.Equal($"Idade minima é de {BirthDate.MinAge} anos.", result.Error.Message);
        }

        [Fact]
        public async void ShouldFailToCreateAnUserWithInvalidCpf()
        {
            var command = UserFaker.CreateUserCommand(false, true).Generate();

            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await _sender.Send(command, CancellationToken.None);
            });
        }

        [Fact]
        public async void ShouldFailToCreateAnUserWithInvalidFullName()
        {
            var command = UserFaker.CreateUserCommand(false, false, true).Generate();

            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await _sender.Send(command, CancellationToken.None);
            });
        }
    }
}
