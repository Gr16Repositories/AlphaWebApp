using AlphaWebApp.Data;
using Microsoft.AspNetCore.Mvc;
namespace AlphaWebApp.ViewComponents
{
    
    public class LatestArticlesViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public LatestArticlesViewComponent( ApplicationDbContext db)
        {
                _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var LatestNews = _db.Articles.Where(x => x.Archive!= true).OrderByDescending(x => x.DateStamp).Take(5).ToList();
            return View("Index", LatestNews);
        }
    }
}
