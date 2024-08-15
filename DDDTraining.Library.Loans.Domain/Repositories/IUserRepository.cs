using DDDTraining.Library.Loans.Domain.Entities;
using DDDTraining.Library.Loans.Domain.Repositories.Base;

namespace DDDTraining.Library.Loans.Domain.Repositories
{
    public interface IUserRepository : IRepository
    {
        User GetById(Guid id);
        public void Add(User user);
    }
}
