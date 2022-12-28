using AlphaWebApp.Data;
using AlphaWebApp.Models.ViewModels;
using AlphaWebApp.Models;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IEmailService _emailService;
        private readonly IArticleService _articleService;

        public UserController(IUserService userService, 
                                ICategoryService categoryService, 
                                IEmailService emailService, 
                                IArticleService articleService)
        {
            _userService = userService;
            _categoryService = categoryService;
            _emailService = emailService;
            _articleService = articleService;
        }

        [Authorize]
        public IActionResult MyPage()
        {
            return View();
        }

        public IActionResult PersonalizedNewsLetter()
        {
            var checkboxList = _categoryService.GetAllCategory();

            return View(checkboxList);
        }

        public IActionResult SubscriptionHistory()
        {
            var UserId = _userService.GetUserId();

            return View(_userService.GetUserSubscriptions(UserId));
        }

        public IActionResult ChangePassword()
        {


            return View();
        }

        public IActionResult SendNewsletterEmail(int id)
        {
            Article articles = _articleService.GetSpecificArticleByCategoryId(id);
            PersonalizedNewsletterVM newsletter = new PersonalizedNewsletterVM();
            newsletter.ArticleId = articles.Id;
            newsletter.ArticleDateStamp = articles.DateStamp;
            newsletter.ArticleHeadLine = articles.HeadLine;
            newsletter.ArticleContentSummary = articles.ContentSummary;
            newsletter.ArticleViews = articles.Views;
            newsletter.ArticleLikes = articles.Likes;
            newsletter.ArticleImageLink = articles.ImageLink;
            newsletter.ArticleCategoryId = articles.CategoryId;
            newsletter.ArticleCategory = articles.Category;
            var result = SendConfirmation(newsletter);
            var resultTuple = new Tuple<string>(result);
            return View(resultTuple);
        }

        public string SendConfirmation(PersonalizedNewsletterVM newsletter)
        {
            return _emailService.SendNewsletterEmail(newsletter).Result;
        }
    }
}
