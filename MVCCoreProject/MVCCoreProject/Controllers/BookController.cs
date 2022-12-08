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
        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult GetAllBooks()
        {
            var data=_bookRepository.getAllBooks();
            return View(data);
        }
        public ViewResult GetBook(int id)
        {
            var data =_bookRepository.getBook(id);
            return View(data);
            
        }
        public List<BookModel> GetBookwithName(string autorname,string title)
        {
            return _bookRepository.getBook(autorname,title);

        }
    }
}
