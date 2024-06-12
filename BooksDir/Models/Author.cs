
using System.Collections.Generic; // Import the namespace for List<T>
using BooksDir.Models; // Import the namespace for Book class

namespace BooksDir.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Book>? Books { get; set; }
    }
}
