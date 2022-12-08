using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
namespace MVCCoreProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [ViewData]
        public string ViewDtaAttributeProperty { get; set; }
        [ViewData]
        public BookModel Bookdata { get; set; }
        public IActionResult Index()
        {
            ViewBag.Title = "Aruna";

            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.Name = "Aruna";
            ViewBag.Data = data;
            ViewBag.Book = new BookModel() { Language = "English" };
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = "Aruna";
            ViewData["data"] = new BookModel() { Id = 1, AuthorName = "ArunaKReddy" };
            return View();
        }

        public IActionResult AboutUS()
        {
            ViewDtaAttributeProperty = "Venkat";
            Bookdata = new BookModel() { AuthorName = "Venkat Reddy" };
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
