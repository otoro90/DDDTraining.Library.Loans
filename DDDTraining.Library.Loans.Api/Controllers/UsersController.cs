using DDDTraining.Library.Loans.Application.Features.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            if (command == null)
                return BadRequest("Invalid user data.");

            var userId = await _mediator.Send(command);
            return CreatedAtAction(nameof(RegisterUser), new { id = userId }, userId);
        }
    }
}
