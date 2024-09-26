using DDDTraining.Library.Loans.Domain.Events;
using DDDTraining.Library.Loans.Domain.Services.Interfaces;
using MediatR;

namespace DDDTraining.Library.Loans.Application.Features.Loan.Commands
{
    public class MakeLoanCommandHandler : IRequestHandler<MakeLoanCmdRequest, Guid>
    {
        private readonly ILoanService _loanService;
        private readonly IMediator _mediator;

        public MakeLoanCommandHandler(ILoanService loanService, IMediator mediator)
        {
            _loanService = loanService;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(MakeLoanCmdRequest request, CancellationToken cancellationToken)
        {
            var loan = await _loanService.MakeLoanAsync(request.UserId, request.BookId);
            await _mediator.Publish(new LoanCreatedEvent(loan.Id, request.UserId, request.BookId), cancellationToken);
            return loan.Id;
        }
    }

}
