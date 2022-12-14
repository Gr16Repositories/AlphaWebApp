using AlphaWebApp.Data;
using AlphaWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Services.ViewComponents
{
    public class NavbarCategoriesViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public NavbarCategoriesViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            List<Category> navbarCategories = _db.Categories.ToList();

            return View("Index", navbarCategories);
        }
    }
}
