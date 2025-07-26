using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksDir.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string GenreName { get; set; }

        public List<Book> Books { get; set; }
    }
}
