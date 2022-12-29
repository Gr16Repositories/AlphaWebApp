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

        // make search and if the user has a subscription they could search in archive 
        public IActionResult Search(string query)
        {
            if(String.IsNullOrEmpty(query))
            {
                return View(new List<Article>());
            }
            var lowerQuery = query.ToLower().Trim();
            
            if (_subscriptionService.HasSubscription(User))
            {
                var articleQuery = _articleService.GetAllArticles().Where(a => a.Content.ToLower().Trim().Contains(lowerQuery)||
                                                            a.ContentSummary.ToLower().Trim().Contains(lowerQuery)||
                                                            a.HeadLine.ToLower().Trim().Contains(lowerQuery));
                return View(articleQuery);
            }
            else if(!String.IsNullOrEmpty(lowerQuery))
            {
                var articleQuery = _articleService.GetAllArticles().Where(a => a.Content.ToLower().Trim().Contains(lowerQuery) &&
                                                            a.Archive == false ||
                                                            a.ContentSummary.ToLower().Trim().Contains(lowerQuery) &&
                                                            a.Archive == false ||
                                                            a.HeadLine.ToLower().Trim().Contains(lowerQuery) &&
                                                            a.Archive == false);
                return View(articleQuery);
            }
            else
            {
                return View(new List<Article>());
            }
        }

    }
}