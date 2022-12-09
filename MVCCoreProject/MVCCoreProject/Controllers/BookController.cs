using Microsoft.AspNetCore.Mvc;
using MVCCoreProject.Models;
using MVCCoreProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreProject.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult> GetAllBooks()
        {
            var data= await _bookRepository.getAllBooks();
            return View(data);
        }
        public async Task<ViewResult> GetBook(int id)
        {
            var data =await _bookRepository.getBook(id);
            return View(data);
            
        }
        public List<BookModel> GetBookwithName(string autorname,string title)
        {
            return _bookRepository.getBook(autorname,title);

        }
        [HttpGet]
        public ViewResult AddBook( bool isSuccess=false,int bookid=0)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.BookId = bookid;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel model)
        {
            if(ModelState.IsValid)
            {
                int id = await _bookRepository.CreateBook(model);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { isSuccess = true, bookid = id });
                }
            }
            ModelState.AddModelError("", "this is my custom error message");
            return View();
        }
    }
}
