using System;
using System.Linq;
using Assignment_05.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_05.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookRepository repository;

        public NavigationMenuViewComponent(IBookRepository repo)
        {
            repository = repo;
        }

        //This method returns a view with each book category. It is passed to the Default.cshtml file
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
