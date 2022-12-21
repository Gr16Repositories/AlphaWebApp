using AlphaWebApp.Data;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;
namespace AlphaWebApp.ViewComponents
{
    public class HealthViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;
        public HealthViewComponent( ApplicationDbContext db, IArticleService articleService)
        {
            _db = db;
            _articleService = articleService;

        }
        public IViewComponentResult Invoke()
        {
            var healthdnews = _articleService.GetArticlesByCategoryName("Health").FirstOrDefault();
            return View("Index", healthdnews);
        }
    }
}
