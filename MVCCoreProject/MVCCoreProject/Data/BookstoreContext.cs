using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreProject.Data
{
    public class BookstoreContext :DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options):base(options)
        {

        }
        public DbSet<BookDataModel> BookData { get; set; }

       
    }
}
