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

                entity.HasMany(o => o.Loans)
                    .WithOne(ol => ol.User)
                    .HasForeignKey(ol => ol.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_BOOK");

                entity.HasMany(o => o.Loans)
                    .WithOne(ol => ol.Book)
                    .HasForeignKey(ol => ol.BookId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasOne(e => e.User)
                .WithMany(e => e.Loans)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Book)
                .WithMany(e => e.Loans)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
