using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BooksDir.Data;
using BooksDir.Models;
using System.Threading.Tasks;
using System.Linq;

namespace BookLibrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookContext _context;

        public BooksController(BookContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .ToListAsync();

            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View(new BookFormModel());
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookFormModel formModel)
        {
            if (!ModelState.IsValid)
                return View(formModel);

            var author = await _context.Authors
                .FirstOrDefaultAsync(a => a.AuthorName.ToLower() == formModel.AuthorName.ToLower());

            if (author == null)
            {
                author = new Author { AuthorName = formModel.AuthorName };
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
            }

            var genre = await _context.Genres
                .FirstOrDefaultAsync(g => g.GenreName.ToLower() == formModel.GenreName.ToLower());

            if (genre == null)
            {
                genre = new Genre { GenreName = formModel.GenreName };
                _context.Genres.Add(genre);
                await _context.SaveChangesAsync();
            }

            var book = new Book
            {
                Title = formModel.Title,
                Description = formModel.Description,
                Pages = formModel.Pages,
                Year = formModel.Year,
                AuthorId = author.Id,
                GenreId = genre.Id
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
                return NotFound();

            var formModel = new BookFormModel
            {
                Title = book.Title,
                Description = book.Description,
                Pages = book.Pages,
                Year = book.Year,
                AuthorName = book.Author?.AuthorName,
                GenreName = book.Genre?.GenreName
            };

            ViewBag.BookId = book.Id;
            return View(formModel);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.BookId = id;
                return View(formModel);
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            var author = await _context.Authors
                .FirstOrDefaultAsync(a => a.AuthorName.ToLower() == formModel.AuthorName.ToLower());
            if (author == null)
            {
                author = new Author { AuthorName = formModel.AuthorName };
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
            }

            var genre = await _context.Genres
                .FirstOrDefaultAsync(g => g.GenreName.ToLower() == formModel.GenreName.ToLower());
            if (genre == null)
            {
                genre = new Genre { GenreName = formModel.GenreName };
                _context.Genres.Add(genre);
                await _context.SaveChangesAsync();
            }

            book.Title = formModel.Title;
            book.Description = formModel.Description;
            book.Pages = formModel.Pages;
            book.Year = formModel.Year;
            book.AuthorId = author.Id;
            book.GenreId = genre.Id;

            _context.Update(book);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: Books/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // Optional: JSON debug endpoint
        public async Task<IActionResult> CheckData()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .ToListAsync();

            return Json(books);
        }
        
         public IActionResult About()
        {
            return View(); 
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
                return NotFound();

            return View(book);
        }

    }
}
