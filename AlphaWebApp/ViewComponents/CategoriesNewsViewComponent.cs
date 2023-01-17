using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;
namespace AlphaWebApp.ViewComponents
{
    public class CategoriesNewsViewComponent: ViewComponent
    {
        private readonly IArticleService _articleService;
        public CategoriesNewsViewComponent( IArticleService articleService)
        {
            _articleService = articleService;
                
        }
        public IViewComponentResult Invoke(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                var allArticles = _articleService.GetAllArticles().OrderByDescending(a=>a.DateStamp).Take(20).ToList();
                return View("Index", allArticles);
            }

            var allcategories = _articleService.GetArticlesByCategoryName(name);
            return View("Index", allcategories);
        }
    }

}
