using MediatR;

namespace DDDTraining.Library.Loans.Domain.Events
{
    public class BookReturnedEvent : INotification
    {
        public Guid LoanId { get; }

        public BookReturnedEvent(Guid loanId)
        {
            LoanId = loanId;
        }
    }
}
