using DDDTraining.Library.Loans.Domain.Entities;

namespace DDDTraining.Library.Loans.Domain.Repositories
{
    public interface ILoanRepository
    {
        Loan GetById(Guid id);
        void Add(Loan prestamo);
        void Update(Loan prestamo);
    }

}
