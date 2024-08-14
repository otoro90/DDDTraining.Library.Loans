using DDDTraining.Library.Loans.Domain.Events;
using MediatR;

namespace DDDTraining.Library.Loans.Application.Features.Loan.Events
{
    public class BookReturnedEventHandler : INotificationHandler<BookReturnedEvent>
    {
        public Task Handle(BookReturnedEvent notification, CancellationToken cancellationToken)
        {
            // Implementar lógica que debe ocurrir cuando un libro es devuelto (actualizar estadísticas, etc.)
            return Task.CompletedTask;
        }
    }

}
