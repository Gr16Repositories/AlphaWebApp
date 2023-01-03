using AlphaWebApp.Data;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;
namespace AlphaWebApp.ViewComponents
{
    public class SwedenViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;
        public SwedenViewComponent(ApplicationDbContext db, IArticleService articleService)
        {
            _db = db;
            _articleService = articleService;

        }

        public IViewComponentResult Invoke()
        {
            var sweden = _articleService.GetArticlesByCategoryName("Sweden").OrderByDescending(x => x.DateStamp).Take(5).ToList(); ;
            return View("Index", sweden);
        }
    }
}
