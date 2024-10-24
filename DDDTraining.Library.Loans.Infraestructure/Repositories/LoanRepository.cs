using DDDTraining.Library.Loans.Domain.Entities;
using DDDTraining.Library.Loans.Domain.Repositories;
using DDDTraining.Library.Loans.Infraestructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DDDTraining.Library.Loans.Infraestructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryDbContext _context;

        public LoanRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public Loan GetById(Guid id)
        {
            return _context.Loans
                .Include(p => p.User)
                .Include(p => p.Book)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Add(Loan prestamo)
        {
            _context.Loans.Add(prestamo);
        }

        public void Update(Loan prestamo)
        {
            _context.Loans.Update(prestamo);
        }
    }

}
