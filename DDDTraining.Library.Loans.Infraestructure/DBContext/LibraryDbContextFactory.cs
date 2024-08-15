using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTraining.Library.Loans.Infraestructure.DBContext
{
    public class LibraryDbContextFactory : IDesignTimeDbContextFactory<LibraryDbContext>
    {
        public LibraryDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=library;User Id=root;Password=123456;");

            return new LibraryDbContext(optionsBuilder.Options);
        }
    }

}
