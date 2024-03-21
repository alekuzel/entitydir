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


//https://www.youtube.com/watch?v=jsAbuhGPT4Q
//https://www.youtube.com/watch?v=ReAoBev65qI

// models: Books, author, genre
//Book: title, year, FK author, FK genre