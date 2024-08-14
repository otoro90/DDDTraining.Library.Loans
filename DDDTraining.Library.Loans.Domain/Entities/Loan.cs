namespace DDDTraining.Library.Loans.Domain.Entities
{
    public class Loan
    {
        public Guid Id { get; private set; }
        public User User { get; private set; }
        public Book Book { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }

        public Loan(Guid id, User user, Book book)
        {
            Id = id;
            User = user ?? throw new ArgumentNullException(nameof(user));
            Book = book ?? throw new ArgumentNullException(nameof(book));
            LoanDate = DateTime.UtcNow;
            ReturnDate = null;
            book.MarkAsUnavailable();
        }

        public void ReturnBook()
        {
            if (ReturnDate.HasValue)
                throw new InvalidOperationException("The book has already been returned.");

            ReturnDate = DateTime.UtcNow;
            Book.MarkAsAvailable();
        }
    }
}
