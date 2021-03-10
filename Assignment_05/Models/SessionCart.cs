using System;
using System.Text.Json.Serialization;
using Assignment_05.Infastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment_05.Models
{
    //inherits from the cart class
    public class SessionCart : Cart
    {
        //retrieves the cart for a specific session
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        //this method overloads the base method
        public override void AddItem(Book book, int quantity)
        {
            base.AddItem(book, quantity);
            Session.SetJson("Cart", this);
        }

        //overloads base method
        public override void SubtractItem(Book book, int quantity)
        {
            base.SubtractItem(book, quantity);
            Session.SetJson("Cart", this);
        }

        //overloads base method
        public override void RemoveLine(Book book)
        {
            base.RemoveLine(book);
            Session.SetJson("Cart", this);
        }

        //overloads base method
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
