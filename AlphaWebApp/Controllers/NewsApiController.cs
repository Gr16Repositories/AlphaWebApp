using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers
{
    public class NewsApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
