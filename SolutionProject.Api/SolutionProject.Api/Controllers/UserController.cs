using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolutionProject.Application.Feature.Users.Commands.AddUser;
using SolutionProject.Application.Feature.Users.Queries.GetListUsers;
using SolutionProject.Application.Feature.Users.Queries.GetUserById;

namespace SolutionProject.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("/api/getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _mediator.Send(new GetUsersListQuery());
            return Ok(response);
        }

        [HttpGet("/api/getUserById/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {   
            var request = new GetUserByIdQuery { Id = id };
            var user = await _mediator.Send(request);
            return Ok(user);
        }


        [HttpPost("/api/addUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
        {
            var resppnse = await _mediator.Send(command);
            return Ok(resppnse);
        }
    }
}
