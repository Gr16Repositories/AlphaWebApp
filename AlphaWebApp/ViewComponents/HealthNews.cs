using AlphaWebApp.Data;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;
namespace AlphaWebApp.ViewComponents
{
    public class HealthViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;
        public HealthViewComponent(ApplicationDbContext db, IArticleService articleService)
        {
            _db = db;
            _articleService = articleService;

        }

        public IViewComponentResult Invoke()
        {
            var health = _articleService.GetArticlesByCategoryName("Health").OrderByDescending(x => x.DateStamp).Take(5).ToList(); ;
            return View("Index", health);
        }
    }
}
