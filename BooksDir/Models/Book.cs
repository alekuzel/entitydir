using System.Collections.Generic; // Import the namespace for List<T>
using BooksDir.Models; // Import the namespace for Book class

namespace BooksDir.Models
{
public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int Pages { get; set; }
    public int Year { get; set; }
    public int AuthorId { get; set; } 
    public string Author { get; set; } 
    public int GenreId { get; set; } 
    public string Genre { get; set; }
}}