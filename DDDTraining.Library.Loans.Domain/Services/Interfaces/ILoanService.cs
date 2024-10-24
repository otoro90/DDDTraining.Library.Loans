using DDDTraining.Library.Loans.Domain.Entities;
using DDDTraining.Library.Loans.Domain.Services.Interfaces.Base;

namespace DDDTraining.Library.Loans.Domain.Services.Interfaces
{
    public interface ILoanService : IDomainService
    {
        Task<Loan> MakeLoanAsync(Guid userId, Guid bookId);
        Task<Loan> ReturnBookAsync(Guid loanId);
    }

}
