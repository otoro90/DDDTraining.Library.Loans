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
        public async Task MakeLoanAsync_Success_LoanServiceTestAsync()
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

            _mockLoanRepository.Setup(repo => repo.Add(It.IsAny<Loan>())).Verifiable();

            // act
            var loan = await _loanService.MakeLoanAsync(user.Id, book.Id);

            //assert
            _mockLoanRepository.Verify(repositorio => repositorio.Add(It.IsAny<Loan>()), "Debe agregar a la base de datos el prestamo");
            loan.Should().NotBeNull();
            loan.UserId.Should().Be(user.Id);
            loan.BookId.Should().Be(book.Id);
        }

        [Fact]
        public async Task ReturnBook_Should_ThrowException_InvalidOperationExceptionAsync()
        {
            //arrange
            var loanFiller = new Filler<Loan>();
            loanFiller.Setup()
                .OnProperty(loan => loan.Book.IsAvailable).Use(true)
                .OnProperty(loan => loan.Book.Loans).IgnoreIt()
                .OnType<Email>().Use(new Email("omigueltoro@gmail.com"))
                .OnType<List<Loan>>().IgnoreIt()
                .ListItemCount(1);

            var loan  = loanFiller.Create();

            _mockLoanRepository.Setup(repositorio => repositorio.GetById(It.IsAny<Guid>())).Returns(loan);

            // act y assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _loanService.ReturnBookAsync(loan.Id));

            Assert.Equal("The book has already been returned.", exception.Message);
        }

        [Fact]
        public async Task ReturnBook_Success_TestAsync()
        {
            //arrange
            var loanFiller = new Filler<Loan>();
            loanFiller.Setup()
                .OnType<Email>().Use(new Email("omigueltoro@gmail.com"))
                .OnProperty(loan => loan.ReturnDate).IgnoreIt()
                .OnProperty(loan => loan.Book.IsAvailable).Use(false)
                .OnProperty(loan => loan.Book.Loans).IgnoreIt()
                .OnType<List<Loan>>().IgnoreIt()
                .ListItemCount(1);

            var loan = loanFiller.Create();

            _mockLoanRepository.Setup(repositorio => repositorio.GetById(It.IsAny<Guid>())).Returns(loan);

            // act 

            var result = await _loanService.ReturnBookAsync(loan.Id);

            // assert
            _mockLoanRepository.Verify(repo => repo.GetById(It.IsAny<Guid>()), "Debe llamar al serivio GetById de LoanRepository");
            _mockLoanRepository.Verify(repo => repo.Update(It.IsAny<Loan>()), "Debe llamar al serivio Update de LoanRepository");
            result.Should().NotBeNull();
            result.ReturnDate.Should().NotBeNull();
            result.Book.IsAvailable.Should().BeTrue();

        }

    }
}
