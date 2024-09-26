using DDDTraining.Library.Loans.Domain.Entities;
using DDDTraining.Library.Loans.Domain.Repositories;
using DDDTraining.Library.Loans.Domain.Repositories.Base;
using DDDTraining.Library.Loans.Domain.Services;
using DDDTraining.Library.Loans.Domain.ValueObjects;
using FluentAssertions;
using Moq;
using Tynamix.ObjectFiller;
using Xunit;

namespace DDDTraining.Library.Loans.Test.DomainServices
{
    public class LoanServiceTest
    {
        private readonly LoanService _loanService;
        private readonly Mock<ILoanRepository> _mockLoanRepository;
        private readonly Mock<IUserRepository> _mockUserepository;
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public LoanServiceTest()
        {
            _mockLoanRepository = new Mock<ILoanRepository>();
            _mockUserepository = new Mock<IUserRepository>();
            _mockBookRepository = new Mock<IBookRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            _loanService = new LoanService(
                _mockLoanRepository.Object, 
                _mockUserepository.Object, 
                _mockBookRepository.Object, 
                _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task LoanServiceTestAsync()
        {
            //arrange
            var userFiller = new Filler<User>();
            userFiller.Setup().OnType<Email>().Use(new Email("otoro@gmail.com")).ListItemCount(1);
            var user = userFiller.Create();

            var bookFiller = new Filler<Book>();
            bookFiller.Setup().OnType<List<Loan>>().IgnoreIt().OnType<bool>().Use(true).ListItemCount(1);
            var book = bookFiller.Create();

            _mockUserepository.Setup(repositorio => repositorio.GetById(It.IsAny<Guid>())).Returns(user);
            _mockBookRepository.Setup(repositorio => repositorio.GetById(It.IsAny<Guid>())).Returns(book);

            // act
            var loan = await _loanService.MakeLoanAsync(user.Id, book.Id);

            //assert

            loan.Should().NotBeNull();
            loan.UserId.Should().Be(user.Id);
            loan.BookId.Should().Be(book.Id);
        }
    }
}
