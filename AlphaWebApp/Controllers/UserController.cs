using AlphaWebApp.Data;
using AlphaWebApp.Models.ViewModels;
using AlphaWebApp.Models;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace AlphaWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IEmailService _emailService;
        private readonly IArticleService _articleService;
        private readonly ISubscriptionService _subscriptionService;
        public UserController(IUserService userService, 
                                ICategoryService categoryService, 
                                IEmailService emailService, 
                                IArticleService articleService,
                                ISubscriptionService subscriptionService
                                )
        {
            _userService = userService;
            _categoryService = categoryService;
            _emailService = emailService;
            _articleService = articleService;
            _subscriptionService = subscriptionService;
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

        // User select categories in order to recive newsletter email based in the first place on Categories Selecletion
        [Authorize]
        public IActionResult GetUserCategoriesSelection()
        {
            Subscription userSubscription = _userService.GetUserSubscriptions(_userService.GetUserId()).FirstOrDefault(s => s.Active);
            UserCategoriesSelectionVM userSelection = new UserCategoriesSelectionVM();

            foreach (var item in _categoryService.GetAllCategory())
            {
                userSelection.Categories.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.name,
                });
            }

            foreach (var category in userSelection.Categories)
            {
                if (userSubscription.Categories.Select(c => c.name).Contains(category.Text))
                {
                    userSelection.Categories.FirstOrDefault(s => s.Text == category.Text).Selected = true;
                }
            }
            return View(userSelection);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult GetUserCategoriesSelection(UserCategoriesSelectionVM uerSelection)
        {
            Subscription userSubscription = _userService.GetUserSubscriptions(_userService.GetUserId()).FirstOrDefault(s => s.Active);
            foreach (var item in uerSelection.Categories)
            {
                if(item.Selected == true)
                {
                    userSubscription.Categories.Add(_categoryService.GetCategoryById(Int32.Parse(item.Value)));
                }
                else
                {
                    userSubscription.Categories.Remove(_categoryService.GetCategoryById(Int32.Parse(item.Value)));
                }
                _subscriptionService.UpdateSubscription(userSubscription);
            }
            return RedirectToAction("SubscriptionHistory");
        }

     


    }
}
