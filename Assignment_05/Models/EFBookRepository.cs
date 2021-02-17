using System;
using System.Linq;

namespace Assignment_05.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookDbContext _context;

        public EFBookRepository(BookDbContext context)
        {
            //sets the _context == the context that is passed in
            _context = context;
        }

        //lambda function that returns _context.Books when the Books is called
        public IQueryable<Book> Books => _context.Books;
    }
}
