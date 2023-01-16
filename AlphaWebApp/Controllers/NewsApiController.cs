using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers
{
    public class NewsApiController : Controller
    {
        private readonly IStorageService _storgeService;

        public NewsApiController(IStorageService storgeService)
        {
                _storgeService= storgeService;
        }
       
        public IActionResult EnglishNews()
        {
            return View(_storgeService.GetLatestEnglishNewsApiArticles());
        }

        public IActionResult SwedishNews()
        {
            return View(_storgeService.GetLatestSwedishNewsApiArticles());
        }

    }
}
