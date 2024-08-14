using DDDTraining.Library.Loans.Domain.Entities;
using DDDTraining.Library.Loans.Domain.Repositories.Base;

namespace DDDTraining.Library.Loans.Domain.Repositories
{
    public interface IBookRepository : IRepository
    {
        Book GetById(Guid id);
        public void Add(Book book);
    }
}
