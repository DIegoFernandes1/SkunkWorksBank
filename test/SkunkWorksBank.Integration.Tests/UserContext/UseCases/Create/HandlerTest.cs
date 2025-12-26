using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SkunkWorksBank.Application.SharedContext.Behavios;
using SkunkWorksBank.Application.UserContext.UseCases.Create;
using SkunkWorksBank.Domain.Users.ValueObjects.Exceptions;

namespace SkunkWorksBank.API.Integration.Tests.UserContext.UseCases.Create
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
            var command = new Command
            (
                FullName: "Diego Fernandes de Meneses",
                Cpf: "09290208040",
                BirthDate: new DateOnly(1994, 5, 12),
                IsPep: false
            );

            var result = await _sender.Send(command, CancellationToken.None);

            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
        }

        [Fact]
        public async void ShouldFailToCreateAnUserWithInvalidBirthDate()
        {
            var command = new Command
           (
               FullName: "Diego Fernandes de Meneses",
               Cpf: "09290208040",
               BirthDate: new DateOnly(2022, 5, 12),
               IsPep: false
           );

            await Assert.ThrowsAsync<InvalidBirthDateException>(async () =>
            {
                await _sender.Send(command, CancellationToken.None);
            });
        }

        [Fact]
        public async void ShouldFailToCreateAnUserWithInvalidCpf()
        {
            var command = new Command
           (
               FullName: "Diego Fernandes de Meneses",
               Cpf: "092902",
               BirthDate: new DateOnly(2022, 5, 12),
               IsPep: false
           );

            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await _sender.Send(command, CancellationToken.None);
            });
        }

        [Fact]
        public async void ShouldFailToCreateAnUserWithInvalidFullName()
        {
            var command = new Command
           (
               FullName: "Di",
               Cpf: "092902",
               BirthDate: new DateOnly(2022, 5, 12),
               IsPep: false
           );

            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await _sender.Send(command, CancellationToken.None);
            });
        }
    }
}
