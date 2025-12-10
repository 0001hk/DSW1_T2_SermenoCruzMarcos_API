using DSW1_T2_SermenoCruzMarcos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System; 

namespace DSW1_T2_SermenoCruzMarcos.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } = null!; 
        public DbSet<Loan> Loans { get; set; } = null!; 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasIndex(b => b.ISBN)
                .IsUnique();
            
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookId);

            
            // Books
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Cien años de soledad", Author = "Gabriel García Márquez", ISBN = "978-0307474728", Stock = 5, CreatedAt = DateTime.Now },
                new Book { Id = 2, Title = "El Señor de los Anillos", Author = "J.R.R. Tolkien", ISBN = "978-0618260234", Stock = 10, CreatedAt = DateTime.Now },
                new Book { Id = 3, Title = "Crónica de una muerte anunciada", Author = "Gabriel García Márquez", ISBN = "978-0307474729", Stock = 2, CreatedAt = DateTime.Now }
            );

            // Loans
            modelBuilder.Entity<Loan>().HasData(
                new Loan { Id = 1, BookId = 1, StudentName = "Marcos Cruz", LoanDate = DateTime.Now.AddDays(-5), ReturnDate = null, Status = "Active", CreatedAt = DateTime.Now.AddDays(-5) },
                new Loan { Id = 2, BookId = 2, StudentName = "Ana Gutiérrez", LoanDate = DateTime.Now.AddDays(-10), ReturnDate = DateTime.Now.AddDays(-8), Status = "Returned", CreatedAt = DateTime.Now.AddDays(-10) }
            );
            
            base.OnModelCreating(modelBuilder);
        }
    }
}