using System;
using System.Linq;

namespace Assignment_05.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
