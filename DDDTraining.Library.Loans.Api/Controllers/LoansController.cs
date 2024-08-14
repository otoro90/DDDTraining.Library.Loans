using DDDTraining.Library.Loans.Application.Features.Loan.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] MakeLoanCmdRequest command)
        {
            var loanId = await _mediator.Send(command);
            return Ok(loanId);
        }
    }

}
