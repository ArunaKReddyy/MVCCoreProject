using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            //ViewBag.LanguageList = new SelectList(GetLanguages(),"Id", "Text");
            //ViewBag.LanguageList = GetLanguages().Select(x => new SelectListItem()
            //{
            //    Value = x.Id.ToString(),
            //    Text = x.Text
            //});
            ViewBag.LanguageList = new List<SelectListItem>()
            {
                new SelectListItem(){Value="1", Text="English"},
                new SelectListItem(){Value="2", Text="Telugu"},
                new SelectListItem(){Value="3", Text="Hindhi"},
                new SelectListItem(){Value="4", Text="Tamil" ,Disabled=true},
                new SelectListItem(){Value="5", Text="Malayalam",Disabled=true},
                new SelectListItem(){Value="6", Text="Kannada", Selected=true},
            };
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
            //ViewBag.LanguageList = new SelectList(GetLanguages(), "Id", "Text");
            //ViewBag.LanguageList = GetLanguages().Select(x => new SelectListItem()
            //{
            //    Value = x.Id.ToString(),
            //    Text = x.Text
            //});
            ModelState.AddModelError("", "this is my custom error message");
            return View();
        }

        private List<LanguageModel> GetLanguages()
        {
            var languagelist = new List<LanguageModel>()
            {
                new LanguageModel(){Id=1,Text="English"},
                 new LanguageModel(){Id=2,Text="Telugu"},
                  new LanguageModel(){Id=3,Text="Hindhi"},
                  new LanguageModel(){Id=4,Text="Kannada"},
            };
            return languagelist;
        }
    }
}
