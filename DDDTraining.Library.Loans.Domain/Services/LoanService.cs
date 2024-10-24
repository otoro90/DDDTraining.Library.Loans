using DDDTraining.Library.Loans.Domain.Entities;
using DDDTraining.Library.Loans.Domain.Repositories;
using DDDTraining.Library.Loans.Domain.Repositories.Base;
using DDDTraining.Library.Loans.Domain.Services.Interfaces;

namespace DDDTraining.Library.Loans.Domain.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LoanService(ILoanRepository loanRepository, IUserRepository userRepository, IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _loanRepository = loanRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Loan> MakeLoanAsync(Guid userId, Guid bookId)
        {
            var user = _userRepository.GetById(userId);
            var book = _bookRepository.GetById(bookId);

            if (user == null)
                throw new InvalidOperationException("User not found.");

            if (book == null)
                throw new InvalidOperationException("Book not found.");

            if (!book.IsAvailable)
                throw new InvalidOperationException("The book is not available for loan.");

            var loan = new Loan(Guid.NewGuid(), user, book);
            _loanRepository.Add(loan);
            await _unitOfWork.CommitAsync(default);
            return loan;
        }

        public async Task<Loan> ReturnBookAsync(Guid loanId)
        {
            var loan = _loanRepository.GetById(loanId);
            loan.ReturnBook();
            _loanRepository.Update(loan);

            await _unitOfWork.CommitAsync(default);

            return loan;
        }
    }
}
