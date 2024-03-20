using Microsoft.AspNetCore.Mvc;
namespace BooksDirectory.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
    }
}
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var books = _bookRepository.GetAllBooks();
            return View(books);
        }
    }
}