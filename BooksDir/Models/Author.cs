using System.ComponentModel.DataAnnotations;

namespace BooksDir.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
