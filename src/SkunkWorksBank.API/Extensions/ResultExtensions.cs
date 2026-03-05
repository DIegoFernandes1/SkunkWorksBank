using Microsoft.AspNetCore.Mvc;
using SkunkWorksBank.Domain.Shared.Common;
using SkunkWorksBank.Domain.Shared.Results;

namespace SkunkWorksBank.API.Extensions
{
    public static class ResultExtensions
    {
        public static IActionResult ToActionResult<T>(this Result<T> result)
        {
            if (result.IsSuccess)
                return new OkObjectResult(result.Value);

            return result.Error.Code switch
            {
                HttpCode.BAD_REQUEST_400 => new BadRequestObjectResult(result.Error),
                HttpCode.NOT_FOUND_404 => new NotFoundObjectResult(result.Error),
                HttpCode.CONFLICT_409 => new ConflictObjectResult(result.Error),
                HttpCode.UNPROCESSABLE_CONTENT_422 => new UnprocessableEntityObjectResult(result.Error),
                _ => new ObjectResult(result.Error) { StatusCode = 500 }
            };
        }
    }
}
