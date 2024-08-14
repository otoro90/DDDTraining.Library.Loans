﻿using DDDTraining.Library.Loans.Domain.Entities;
using DDDTraining.Library.Loans.Domain.Repositories;
using DDDTraining.Library.Loans.Infraestructure.DBContext;
using System;

namespace DDDTraining.Library.Loans.Infraestructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public void Add(Book book)
        {
            _context.Books.Add(book);
        }

        public Book GetById(Guid id)
        {
            return _context.Books.Find(id);
        }
    }

}
