using MediatR;

namespace DDDTraining.Library.Loans.Application.Features.Loan.Commands
{
    public class MakeLoanCmdRequest : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }

        public MakeLoanCmdRequest(Guid userId, Guid bookId)
        {
            UserId = userId;
            BookId = bookId;
        }
    }

}
