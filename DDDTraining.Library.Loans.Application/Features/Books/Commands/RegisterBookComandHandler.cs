using DDDTraining.Library.Loans.Domain.Entities;
using DDDTraining.Library.Loans.Domain.Repositories;
using DDDTraining.Library.Loans.Domain.Repositories.Base;
using MediatR;

namespace DDDTraining.Library.Loans.Application.Features.Books.Commands
{
    public class RegisterBookCommandHandler : IRequestHandler<RegisterBookCommand, Guid>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterBookCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Guid> Handle(RegisterBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(Guid.NewGuid(), request.Title, request.Author, request.ISBN);

            _bookRepository.Add(book); // Implement the Add method in IBookRepository
            _unitOfWork.CommitAsync(cancellationToken);
            return Task.FromResult(book.Id);
        }
    }

}
