using DDDTraining.Library.Loans.Domain.Entities;
using DDDTraining.Library.Loans.Domain.Services.Interfaces.Base;

namespace DDDTraining.Library.Users.Domain.Services.Interfaces
{
    public interface IUserService : IDomainService
    {
        Task<User> AddUserAsync(User user);
    }

}
