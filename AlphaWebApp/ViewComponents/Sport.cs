using AlphaWebApp.Data;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;
namespace AlphaWebApp.ViewComponents
{
    public class SportViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;
        public SportViewComponent(ApplicationDbContext db, IArticleService articleService)
        {
            _db = db;
            _articleService = articleService;

        }

        public IViewComponentResult Invoke()
        {
            var sport = _articleService.GetArticlesByCategoryName("Sport").OrderByDescending(x => x.DateStamp).Take(5).ToList(); ;
            return View("Index", sport);
        }
    }
}
