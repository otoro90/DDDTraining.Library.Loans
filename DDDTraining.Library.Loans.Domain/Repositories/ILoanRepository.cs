using DDDTraining.Library.Loans.Domain.Entities;
using DDDTraining.Library.Loans.Domain.Repositories.Base;

namespace DDDTraining.Library.Loans.Domain.Repositories
{
    public interface ILoanRepository : IRepository
    {
        Loan GetById(Guid id);
        void Add(Loan prestamo);
        void Update(Loan prestamo);
    }

}
