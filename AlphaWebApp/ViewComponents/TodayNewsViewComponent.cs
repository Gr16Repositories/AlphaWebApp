using AlphaWebApp.Data;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;
namespace AlphaWebApp.ViewComponents
{
    public class TodayNewsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;
        public TodayNewsViewComponent(ApplicationDbContext db,
            IArticleService articleService)
        {
            _db = db;
            _articleService = articleService;
        }
        public IViewComponentResult Invoke()
        {
            
            var todaynews = _articleService.GetArticlesByCategoryName("Local").OrderByDescending(x => x.DateStamp).FirstOrDefault();
            return View("Index", todaynews);
        }
    }
}
