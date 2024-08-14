using MediatR;

namespace DDDTraining.Library.Loans.Application.Features.Users.Commands
{
    public class RegisterUserCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
