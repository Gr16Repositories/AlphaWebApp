using AlphaWebApp.Data;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;
namespace AlphaWebApp.ViewComponents
{
    public class SportsViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;
        public SportsViewComponent( ApplicationDbContext db, IArticleService articleService)
        {
            _db = db;
            _articleService = articleService;

        }

        public IViewComponentResult Invoke()
        {
            var sport = _articleService.GetArticlesByCategoryName("Sport").FirstOrDefault();
            return View("Index", sport);
        }

    }
}
