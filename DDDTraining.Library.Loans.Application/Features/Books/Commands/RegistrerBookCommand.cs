using MediatR;

namespace DDDTraining.Library.Loans.Application.Features.Books.Commands
{
    public class RegisterBookCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }
    }

}
