using DDDTraining.Library.Loans.Domain.Entities;

namespace DDDTraining.Library.Loans.Domain.Services.Interfaces
{
    public interface ILoanService
    {
        Loan MakeLoan(Guid userId, Guid bookId);
        void ReturnBook(Loan loan);
    }

}
