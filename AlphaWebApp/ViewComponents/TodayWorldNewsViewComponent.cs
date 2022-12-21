using AlphaWebApp.Data;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;
namespace AlphaWebApp.ViewComponents
{
    public class TodayWorldNewsViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;
        public TodayWorldNewsViewComponent( ApplicationDbContext db, IArticleService articleService)
        {
            _db = db;
            _articleService = articleService;

        }
        public IViewComponentResult Invoke()
        {
            var todayworldnews = _articleService.GetArticlesByCategoryName("World").FirstOrDefault();
            return View("Index", todayworldnews);
        }
    }
}
