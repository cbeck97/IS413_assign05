using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_05.Models
{
    public class Cart
    {
        //This is a list that stores each line item of the cart that will be displayed
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //This is the base method that enables an item to be added to a cart
        public virtual void AddItem(Book book, int qty)
        {
            //grab the line that stores the book that is being added
            CartLine line = Lines
                .Where(p => p.Book.BookID == book.BookID)
                .FirstOrDefault();

            //If nothing is returned, the book is not currently in the Lines list
            //If that is the case, add the book to the list and set the qty of for that book
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = qty
                });
            }
            //If the book is already in the list, increase the quantity
            else
            {
                line.Quantity += qty;
            }
        }

        //This enables the user to decrease the qty of an item in the cart
        public virtual void SubtractItem(Book book, int qty)
        {
            CartLine line = Lines
                .Where(p => p.Book.BookID == book.BookID)
                .FirstOrDefault();
            //If the current qty == 1, remove the item. You cannot have 0 items in the cart
            if(line.Quantity == 1){
                RemoveLine(book);
            }
            else
            {
                line.Quantity -= qty;
            }

            
        }

        //This removes the entire line from the cart
        public virtual void RemoveLine(Book book) =>
            Lines.RemoveAll(x => x.Book.BookID == book.BookID);

        //This clears out the whole cart
        public virtual void Clear() => Lines.Clear();

        //Computes the total cost of all of the items in the cart
        public double ComputeTotalSum() =>
            Lines.Sum(e => e.Book.Price * e.Quantity);

        //sub class that is the type for the Lines list
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
