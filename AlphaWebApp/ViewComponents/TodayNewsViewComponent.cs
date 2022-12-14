using AlphaWebApp.Data;
using Microsoft.AspNetCore.Mvc;
namespace AlphaWebApp.ViewComponents
{
    public class TodayNewsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public TodayNewsViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var todaynews = _db.Articles.FirstOrDefault(a => a.CategoryId == 2);
            return View("Index", todaynews);
        }
    }
}
