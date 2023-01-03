using AlphaWebApp.Data;
using Microsoft.AspNetCore.Mvc;
namespace AlphaWebApp.ViewComponents
{
    public class MostPopularViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public MostPopularViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var mostpopular = _db.Articles.Where(x => x.Archive != true).OrderByDescending(x => x.Views).Take(5).ToList();
            return View("Index", mostpopular);
        }

    }
}
