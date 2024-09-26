using DDDTraining.Library.Loans.Domain.Entities;
using DDDTraining.Library.Loans.Domain.Repositories;
using DDDTraining.Library.Loans.Domain.Repositories.Base;
using DDDTraining.Library.Loans.Domain.ValueObjects;
using MediatR;

namespace DDDTraining.Library.Loans.Application.Features.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegistrerUserCmdRequest, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(RegistrerUserCmdRequest request, CancellationToken cancellationToken)
        {
            var email = new Email(request.Email); // Assuming Email is a Value Object
            var user = new User(Guid.NewGuid(), request.Name, email);

            _userRepository.Add(user); // Implement the Add method in IUserRepository
            await _unitOfWork.CommitAsync(cancellationToken);
            return user.Id;
        }
    }

}
