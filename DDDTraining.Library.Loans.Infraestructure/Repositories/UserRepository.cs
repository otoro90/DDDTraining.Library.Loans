using DDDTraining.Library.Loans.Domain.Entities;
using DDDTraining.Library.Loans.Domain.Repositories;
using DDDTraining.Library.Loans.Infraestructure.DBContext;
using System;

namespace DDDTraining.Library.Loans.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _context;

        public UserRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public User GetById(Guid id)
        {
            return _context.Users.Find(id);
        }
    }
}
