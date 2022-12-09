using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers
{
    public class User : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
