using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_05.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Assignment_05.Infastructure;

namespace Assignment_05.Pages
{
    //this is the model that is associated with the cart razor page.
    //The various post methods used in the page are configured here
    public class CartModel : PageModel
    {
        private IBookRepository repository;

        public CartModel(IBookRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        //This adds an item to the cart
        public IActionResult OnPost(long bookID, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(p => p.BookID == bookID);

            Cart.AddItem(book, 1);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        //This removes an item from the cart when the remove button is pressed
        public IActionResult OnPostRemove(long bookID, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Book.BookID == bookID).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        //This is used to increase the quantity of an item in the cart
        public IActionResult OnPostAdd(int bookID, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(p => p.BookID == bookID);
            Cart.AddItem(book, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        //This is used to decrease the quantity of an item in the cart
        public IActionResult OnPostSubtract(int bookID, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(p => p.BookID == bookID);
            Cart.SubtractItem(book, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
