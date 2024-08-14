namespace DDDTraining.Library.Loans.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public bool IsAvailable { get; private set; }

        public Book(Guid id, string title, string author, string isbn)
        {
            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Author = author ?? throw new ArgumentNullException(nameof(author));
            ISBN = isbn ?? throw new ArgumentNullException(nameof(isbn));
            IsAvailable = true;
        }

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
