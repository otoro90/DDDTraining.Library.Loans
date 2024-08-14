using DDDTraining.Library.Loans.Domain.ValueObjects;

namespace DDDTraining.Library.Loans.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Email Email { get; private set; }

        public User(Guid id, string name, Email email)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }
    }

}
