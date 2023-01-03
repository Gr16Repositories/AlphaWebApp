using AlphaWebApp.Data;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;
namespace AlphaWebApp.ViewComponents
{
    public class EconomyViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;
        public EconomyViewComponent(ApplicationDbContext db, IArticleService articleService)
        {
            _db = db;
            _articleService = articleService;

        }

        public IViewComponentResult Invoke()
        {
            var economy = _articleService.GetArticlesByCategoryName("Economy").OrderByDescending(x => x.DateStamp).Take(3).ToList(); ;
            return View("Index", economy);
        }
    }
}
