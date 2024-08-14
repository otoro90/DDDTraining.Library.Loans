using DDDTraining.Library.Loans.Domain.Entities;

namespace DDDTraining.Library.Loans.Domain.Repositories
{
    public interface IUserRepository
    {
        User GetById(Guid id);
        public void Add(User user);
    }
}
