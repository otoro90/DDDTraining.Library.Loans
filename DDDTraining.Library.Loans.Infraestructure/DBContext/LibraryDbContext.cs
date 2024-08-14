using DDDTraining.Library.Loans.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDTraining.Library.Loans.Infraestructure.DBContext
{
    public partial class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_USER");

                entity.OwnsOne(u => u.Email, email =>
                {
                    email.Property(e => e.Address).IsRequired().HasMaxLength(128);
                });
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_USER");
            });

            modelBuilder.Entity<Loan>( entity =>
            {
                entity.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.User.Id);

                entity.HasOne(p => p.Book)
                .WithMany()
                .HasForeignKey(p => p.Book.Id);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
