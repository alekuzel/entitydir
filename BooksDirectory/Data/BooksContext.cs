using BooksDirectory.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksDirectory.Data
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}