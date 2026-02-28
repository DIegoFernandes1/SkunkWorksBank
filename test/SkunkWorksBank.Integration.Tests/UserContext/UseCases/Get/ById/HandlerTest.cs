using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SkunkWorksBank.API.Integration.Tests.Fakers;
using SkunkWorksBank.Application.UserContext.UseCases.Get.ById;

namespace SkunkWorksBank.API.Integration.Tests.UserContext.UseCases.Get.ById
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
        public async void ShouldFindUserById()
        {
            var command = UserFaker.CreateUserCommand().Generate();

            var resultCommand = await _sender.Send(command, CancellationToken.None);

            Assert.True(resultCommand.IsSuccess);

            var query = new Query
            (
                Id: resultCommand.Value.id
            );

            var resultQuery = await _sender.Send(query, CancellationToken.None);

            Assert.True(resultQuery.IsSuccess);
            Assert.NotNull(resultQuery.Value);
        }

        [Fact]
        public async void ShouldFailToFindUserById()
        {
            var query = new Query
            (
                Id: new Guid()
            );

            var resultQuery = await _sender.Send(query, CancellationToken.None);

            Assert.NotNull(resultQuery);
            Assert.True(resultQuery.IsFailure);
        }

    }
}
