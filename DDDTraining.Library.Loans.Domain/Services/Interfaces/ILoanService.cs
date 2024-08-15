using DDDTraining.Library.Loans.Domain.Entities;
using DDDTraining.Library.Loans.Domain.Services.Interfaces.Base;

namespace DDDTraining.Library.Loans.Domain.Services.Interfaces
{
    public interface ILoanService : IDomainService
    {
        Loan MakeLoan(Guid userId, Guid bookId);
        void ReturnBook(Loan loan);
    }

}
