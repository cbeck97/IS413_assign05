using System;
namespace Assignment_05.Models.ViewModels
{
    //This is a class that stores the information regarding the paging information. This will
    //be passed to the html view along with the IEnumerable<Books>
    public class PagingInfo
    {
        public int TotalNumItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)(Math.Ceiling((decimal)TotalNumItems / ItemsPerPage));
    }
}
