using Microsoft.EntityFrameworkCore;
using MVCCoreProject.Data;
using MVCCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreProject.Repository
{
    public class BookRepository
    {

        private readonly BookstoreContext _context =null;
         public BookRepository(BookstoreContext context)
        {
            _context = context;
        }
        public async Task<int> CreateBook(BookModel bookModel)
        {
            var newbook = new BookDataModel()
            {
                Title = bookModel.Title,
                AuthorName = bookModel.AuthorName,
                Description = bookModel.Description,
                Totalpages = bookModel.Totalpages,
                Language=bookModel.Language
            };
            await _context.BookData.AddAsync(newbook);
            await _context.SaveChangesAsync();
            return newbook.Id;
        }
        public async Task<List<BookModel>> getAllBooks()
        {
            //return DataSource();

            var allbooks = new List<BookModel>();
            var data = await _context.BookData.ToListAsync();
            if(data?.Any()==true)
            {
                foreach (var item in data)
                {
                    allbooks.Add(
                        new BookModel()
                        {
                            Title = item.Title,
                            AuthorName = item.AuthorName,
                            Description = item.Description,
                            Totalpages = item.Totalpages,
                            Language=item.Language,
                            Id=item.Id
                        });
                }
            }
            return allbooks;
        }
        public async Task<BookModel> getBook(int id)
        {
            var allbooks = new BookModel();
            var book = await _context.BookData.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(book !=null)
            {
                allbooks = (new BookModel()
                {
                    Title = book.Title,
                    AuthorName = book.AuthorName,
                    Description = book.Description,
                    Totalpages = book.Totalpages,
                    Language=book.Language,
                    Id = book.Id
                }); ;
                return allbooks;
            }
            return null;
        }
        public List<BookModel> getBook(string author,string title)
        {
            var book = DataSource().Where(x => x.AuthorName.Contains(author) || x.Title.Contains(title)).ToList();
            return book;
        }
        public List<BookModel> DataSource()
        {
            var booklist = new List<BookModel>()
            {
                new BookModel(){ Id=1,AuthorName="ArunaKReddy",Title="MVC",Description="This is the book to learn MVC",Language="English",Totalpages="1298",Category="Framework"},
                 new BookModel(){ Id=2,AuthorName="ArunaKReddy",Title="c#",Description="This is the book to learn C#" ,Language="English",Totalpages="198",Category="Language"},
                  new BookModel(){ Id=3,AuthorName="ArunaKReddy",Title="Python",Description="This is the book to learn Python",Language="English",Totalpages="1277",Category="Programming" },
                   new BookModel(){ Id=4,AuthorName="ArunaKReddy",Title="WebAPI" ,Description="This is the book to learn WebAPI",Language="English",Totalpages="444",Category="Framework"},
                    new BookModel(){ Id=5,AuthorName="ArunaKReddy",Title="SQL" ,Description="This is the book to learn SQL",Language="English",Totalpages="899",Category="Language"},
            };
            return booklist;
        }
    }
}
