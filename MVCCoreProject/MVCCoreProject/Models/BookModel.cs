using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreProject.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public string Category { get; set; }
        public string Totalpages { get; set; }
        public string Language { get; set; }
    }
}
