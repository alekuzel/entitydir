using BooksDir.Models;
using Microsoft.AspNetCore.Mvc;

namespace books.Controllers {
    public class BooksController : Controller {

        public IActionResult Index() {
            return View();
        }  

        public IActionResult Create() {
            return View();
        }  
        [HttpPost] 

           public IActionResult Create(Book book) {
            return View();
        }

        public IActionResult Edit(int id) {
            return View();
        } 
    }
}