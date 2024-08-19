using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolutionProject.Application.Feature.Users.Commands.AuthentificationUser;

namespace SolutionProject.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/api/login")]
        public async Task<IActionResult> Authentification([FromBody] AuthentificationUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsAuthSuccessful)
            {
                return Unauthorized(result.ErrorMessage);
            }

            return Ok(new { result });
        }
    }
}
