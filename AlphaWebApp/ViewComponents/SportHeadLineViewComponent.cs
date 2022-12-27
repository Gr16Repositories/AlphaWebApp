using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.ViewComponents
{
    public class SportHeadLineViewComponent: ViewComponent
    {
        private readonly IArticleService _articleService;
        public SportHeadLineViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IViewComponentResult Invoke()
        {
            var sportHead = _articleService.GetArticlesByCategoryName("Sport").Take(5);
            return View("Index", sportHead);
        }
    }
}
