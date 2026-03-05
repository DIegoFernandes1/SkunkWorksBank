using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkunkWorksBank.Application.UserContext.UseCases.Create.Users;
using SkunkWorksBank.Application.UserContext.UseCases.Create.Contacts;
using SkunkWorksBank.Application.UserContext.UseCases.Get.ById;
using SkunkWorksBank.API.Extensions;

namespace SkunkWorksBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender sender;

        public UserController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCommand command, CancellationToken cancellationToken)
        {
            var result = await sender.Send(command, cancellationToken);

            return result.ToActionResult();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Query query, CancellationToken cancellationToken)
        {
            var result = await sender.Send(query, cancellationToken);

            return result.ToActionResult();
        }

        [HttpPost]
        [Route("AddContact")]
        public async Task<IActionResult> AddContact(ContactCommand command, CancellationToken cancellationToken)
        {
            var result = await sender.Send(command, cancellationToken);

            return result.ToActionResult();
        }
    }
}
