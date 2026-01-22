using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkunkWorksBank.Application.UserContext.UseCases.Create;
using SkunkWorksBank.Application.UserContext.UseCases.Get;

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
        public async Task<IActionResult> Create(Command command, CancellationToken cancellationToken)
        {
            var result = await sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Query query, CancellationToken cancellationToken)
        {
            var result = await sender.Send(query, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result);
        }
    }
}
