using Lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    public class BookController1 : Controller
    {
        protected Book book = new Book();
        public IActionResult Index()
        {
            //Danh sách genre convert selcectlistitem để hiển thị trên Combobox
            ViewBag.authour = book.author; // Truyền dữ liệu selcectlistitem qua View
            ViewBag.genre = book.genre;
            var books = book.GetBookList();
            return View(books); // Truyền dữ liệu qua view dưới dang tham số
        }
        public IActionResult Create()
        {
            ViewBag.authour = book.author; // Truyền dữ liệu selcectlistitem qua View
            ViewBag.genre = book.genre;
            var model = new Book();
            return View(model); 
        }
        public IActionResult Edit(int id)
        {
            ViewBag.authour = book.author; // Truyền dữ liệu selcectlistitem qua View
            ViewBag.genre = book.genre;
            var model = book.GetBookById(id);
            return View(model);
        }
    }
}
