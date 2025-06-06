using System.ComponentModel.DataAnnotations;

namespace BooksDir.Models
{
    public class Genre
    {
        public int GenreId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
