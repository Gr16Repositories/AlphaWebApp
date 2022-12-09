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


        public IActionResult AddArticle()
        {

            AddArticleVM newArticle = new();
            // Should change - fetch Categories from db table
            newArticle.Categories.Add(new SelectListItem { Text = "Sports", Value= "3"});
            newArticle.Categories.Add(new SelectListItem { Text = "World", Value = "4" });
            newArticle.Categories.Add(new SelectListItem { Text = "Local", Value = "5" });

            return View(newArticle);
        }



        // adding addArticle to database throw services
        [HttpPost]
        public IActionResult AddArticle(AddArticleVM newArticle)
        {
            string folderPath = "wwwroot/images/articles" + "/" + newArticle.CategoryId;
            string path = Path.Combine(Directory.GetCurrentDirectory(), folderPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileNameWithPath = Path.Combine(path, newArticle.FileName);
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                newArticle.File.CopyTo(stream);
            }
            // now the file is store locally we need to store it on Azure bolb

            string pathFile = newArticle.CategoryId + "/" + newArticle.File.FileName;
            Uri blobUri = _storageService.uploadBlob(pathFile);
            _articleService.SaveArticle(newArticle, blobUri);


            // Add article to table in ArticleService
            return RedirectToAction("Index");
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