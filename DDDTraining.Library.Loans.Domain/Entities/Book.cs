namespace DDDTraining.Library.Loans.Domain.Entities
{
    public class Book
    {
        private Book() { }
        public Book(Guid id, string title, string author, string isbn)
        {
            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Author = author ?? throw new ArgumentNullException(nameof(author));
            ISBN = isbn ?? throw new ArgumentNullException(nameof(isbn));
            IsAvailable = true;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public bool IsAvailable { get; private set; }
        public List<Loan> Loans { get; private set; }

        public void MarkAsUnavailable()
        {
            IsAvailable = false;
        }

        public void MarkAsAvailable()
        {
            IsAvailable = true;
        }
    }
}
