using DDDTraining.Library.Loans.Domain.Events;
using MediatR;

namespace DDDTraining.Library.Loans.Application.Features.Loan.Events
{
    public class LoanCreatedEventHandler : INotificationHandler<LoanCreatedEvent>
    {
        public Task Handle(LoanCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Implementar lógica que debe ocurrir cuando un libro es prestado (enviar un correo, etc.)
            return Task.CompletedTask;
        }
    }
}
