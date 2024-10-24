using DDDTraining.Library.Loans.Domain.Entities;
using DDDTraining.Library.Loans.Domain.Repositories;
using DDDTraining.Library.Loans.Domain.Repositories.Base;
using DDDTraining.Library.Loans.Domain.ValueObjects;
using DDDTraining.Library.Users.Domain.Services;
using Moq;
using Tynamix.ObjectFiller;
using Xunit;

namespace DDDTraining.Library.Users.Test.DomainServices
{
    public class UserServiceTest
    {
        private readonly UserService _userService;
        private readonly Mock<IUserRepository> _mockUserepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public UserServiceTest()
        {
            _mockUserepository = new Mock<IUserRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            _userService = new UserService(
                _mockUserepository.Object, 
                _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task AddUserAsync_Success_UserServiceTest()
        {
            //arrange
            var userFiller = new Filler<User>();
            userFiller.Setup().OnType<Email>().Use(new Email("otoro@gmail.com")).ListItemCount(1);
            var user = userFiller.Create();

            _mockUserepository.Setup(repositorio => repositorio.Add(It.IsAny<User>())).Verifiable();

            // act

            var result = await _userService.AddUserAsync(user);

            //assert

            _mockUserepository.Verify(repo => repo.Add(It.IsAny<User>()), "Debe llamar al serivio Add de UserRepository");

        }
    }
}
