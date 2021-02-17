using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment_05.Models
{
    public class Book
    {
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

        [Required]
        [RegularExpression(@"^\d{3}-\d{10}$", ErrorMessage = "Not a valid ISBN number")]
        public string ISBN { get; set; }

        [Required]
        public string Classification { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
