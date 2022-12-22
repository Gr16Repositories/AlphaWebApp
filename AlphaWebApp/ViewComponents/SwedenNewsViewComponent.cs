using AlphaWebApp.Data;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.ViewComponents
{
    public class SwedenNewsViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;
        public SwedenNewsViewComponent(ApplicationDbContext db,
            IArticleService articleService)
        {
            _db = db;
            _articleService = articleService;

        }
        public IViewComponentResult Invoke()
        {
            // Sweden news
            var swedennews = _articleService.GetArticlesByCategoryName("Sweden").Take(7);
            return View("Index", swedennews);
        }

    }
}
