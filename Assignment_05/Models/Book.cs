using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment_05.Models
{
    public class Book
    {
        //START OF Fields in the Model -------------------------------------------------------------------

        //This is the primary key for the table that is created in the database
        [Key]
        public int BookID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AuthorFirstName { get; set; }

        public string AuthorMiddleInitial { get; set; }

        [Required]
        public string AuthorLastName { get; set; }

        [Required]
        public string Publisher { get; set; }

        //This RegEx makes sure that the ISBN is in the following Format:
        //###-##########
        [Required]
        [RegularExpression(@"^\d{3}-\d{10}$", ErrorMessage = "Not a valid ISBN number")]
        public string ISBN { get; set; }

        [Required]
        public string Classification { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int PageCount { get; set; }

        //END OF Fields in the Model -------------------------------------------------------------------

    }
}
