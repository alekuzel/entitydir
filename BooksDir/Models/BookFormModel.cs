using System.ComponentModel.DataAnnotations;

namespace BooksDir.Models
{
    public class BookFormModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Pages must be positive")]
        public int Pages { get; set; }

        [Range(1000, 2100, ErrorMessage = "Year must be realistic")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Author name is required")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Genre name is required")]
        public string GenreName { get; set; }
    }
}
