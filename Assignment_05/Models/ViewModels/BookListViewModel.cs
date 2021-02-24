using System;
using System.Collections.Generic;

namespace Assignment_05.Models.ViewModels
{
    //This is the information that will be passed to the HTML page for loading up the data.
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
