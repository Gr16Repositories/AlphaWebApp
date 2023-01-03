using AlphaWebApp.Data;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;
namespace AlphaWebApp.ViewComponents
{
    public class WorldViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;
        public WorldViewComponent(ApplicationDbContext db, IArticleService articleService)
        {
            _db = db;
            _articleService = articleService;

        }

        public IViewComponentResult Invoke()
        {
            var world = _articleService.GetArticlesByCategoryName("World").OrderByDescending(x => x.DateStamp).Take(5).ToList(); ;
            return View("Index", world);
        }
    }
}
