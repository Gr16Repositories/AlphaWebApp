using AlphaWebApp.Data;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;

        public UserController(IUserService userService, ICategoryService categoryService)
        {
            _userService = userService;
            _categoryService = categoryService;
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
    }
}
