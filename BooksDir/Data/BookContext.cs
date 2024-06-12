using BooksDir.Models; // Import the namespace for Book class   
using Microsoft.EntityFrameworkCore; // Import the namespace for DbContext  
namespace BooksDir.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public DbSet<Book>? Books { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Genre>? Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId);
        }
    }  } 