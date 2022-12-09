using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreProject.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [StringLength(100,MinimumLength=5)]
        [Required(ErrorMessage = "Please enter a  AuthorName for your book")]
        public string AuthorName { get; set; }
        [Required(ErrorMessage = "Please enter a  title for your book")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a  Description for your book")]
        public string Description { get; set; }
        
        public string Category { get; set; }
        [Required]
        [Display(Name = "Total Number of pages")]
        public string Totalpages { get; set; }
        public string Language { get; set; }


        [DataType(DataType.EmailAddress)]
        [Display(Name ="EmailAddress")]
        [EmailAddress]
        [Required(ErrorMessage = "Enter Email Address")]
        public string EmailAddress { get; set; }
    }
}
