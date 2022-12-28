using AlphaWebApp.Data;
using AlphaWebApp.Models;
using AlphaWebApp.Models.ViewModels;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AlphaWebApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;
        private readonly IStorageService _storageService;
        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;
        private readonly ISubscriptionService _subscriptionService;


        public HomeController(/*ILogger<HomeController> logger,*/
                                IEmailService emailService,
                                IStorageService storageService,
                                ApplicationDbContext db,
                                IArticleService articleService,
                                ISubscriptionService subscriptionService
                             )
        {
            //_logger = logger;
            _emailService = emailService;
            _storageService = storageService;
            _db = db;
            _articleService = articleService;
            _subscriptionService = subscriptionService;
        }

        public IActionResult Index()
        {
            return View(_articleService.GetAllArticles());
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        public IActionResult Search()
        {
            return View(new Article());
        }


        [HttpPost]
        public IActionResult Search(string query)
        {
            var articlesList = _db.Articles.ToList();
            if (_subscriptionService.HasSubscription(User))
            {
                var articleQuery = articlesList.Where(a => a.Content.Contains(query));
                return View(articleQuery);
            }
            else if(!String.IsNullOrEmpty(query))
            {
                var articleQuery = articlesList.Where(a => a.Content.Contains(query) && a.Archive == false);
                return View(articleQuery);
            }
            else
            {
                return View(new List<Article>());
            }
        }

    }
}