using System;
using System.Linq;

namespace Assignment_05.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookDbContext _context;

        public EFBookRepository(BookDbContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;
    }
}
