using AlphaWebApp.Data;
using AlphaWebApp.Models;
using AlphaWebApp.Models.ViewModels;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace AlphaWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;
        private readonly IStorageService _storageService;
        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;


        public HomeController(ILogger<HomeController> logger,
                                IEmailService emailService,
                                IStorageService storageService,
                                ApplicationDbContext db, 
                                IArticleService articleService
                             )
        {
            _logger = logger;
            _emailService = emailService;
            _storageService = storageService;
            _db = db;
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            return View(_articleService.GetAllArticles());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Articles( int id)
        {
            //var articles =    _articlesServices.GetArticles(id)
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }  

        // when user click supsucription button
        public IActionResult CreateSubscription()
        {
            Email newEmail = new()
            {
                SubscriberEmail = "Fadi.abji@hotmail.com",
                SubscriptionTypeName = "Basic",
                SubscriberName = "Fadi Abji"
            };
            TempData["ShowMessage"] = SendConfirmation(newEmail);
            return RedirectToAction("Privacy");
            //return RedirectToAction("UserPage", "User");
        }

        public string SendConfirmation(Email newEmail)
        {
            return _emailService.SendSubscriptionEmail(newEmail).Result;
        }

        //Article Read More button
        public IActionResult ReadMore()
        {
            var test = _articleService.GetAllArticles().FirstOrDefault();
            return View(test);
        }
    }
}