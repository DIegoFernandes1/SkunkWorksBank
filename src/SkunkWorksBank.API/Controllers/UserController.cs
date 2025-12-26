using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkunkWorksBank.Application.UserContext.UseCases.Create;

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
        public async Task<IActionResult> Create(Command command)
        {
            var result = await sender.Send(command);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result);
        }
    }
}
