using DDDTraining.Library.Loans.Application.Features.Books.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterBook([FromBody] RegistrerBookCmdRequest command)
        {
            if (command == null)
                return BadRequest("Invalid book data.");

            var bookId = await _mediator.Send(command);
            return CreatedAtAction(nameof(RegisterBook), new { id = bookId }, bookId);
        }
    }
}
