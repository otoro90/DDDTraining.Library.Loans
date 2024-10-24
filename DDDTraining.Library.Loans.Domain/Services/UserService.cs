using DDDTraining.Library.Loans.Domain.Entities;
using DDDTraining.Library.Loans.Domain.Repositories;
using DDDTraining.Library.Loans.Domain.Repositories.Base;
using DDDTraining.Library.Users.Domain.Services.Interfaces;

namespace DDDTraining.Library.Users.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> AddUserAsync(User user)
        {
            _userRepository.Add(user);

            await _unitOfWork.CommitAsync(default);

            return user;
        }
    }
}
