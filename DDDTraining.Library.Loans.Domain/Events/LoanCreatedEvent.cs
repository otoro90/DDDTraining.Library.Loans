using MediatR;

namespace DDDTraining.Library.Loans.Domain.Events
{
    public class LoanCreatedEvent : INotification
    {
        public Guid LoanId { get; }
        public Guid UserId { get; }
        public Guid BookId { get; }

        public LoanCreatedEvent(Guid loanId, Guid userId, Guid bookId)
        {
            LoanId = loanId;
            UserId = userId;
            BookId = bookId;
        }
    }
}
