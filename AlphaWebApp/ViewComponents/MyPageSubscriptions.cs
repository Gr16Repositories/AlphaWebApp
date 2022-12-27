using AlphaWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.ViewComponents
{
    public class MyPageSubscriptions : ViewComponent
    {
        private readonly IUserService _userService;

        public MyPageSubscriptions (IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        public IViewComponentResult Invoke()
        {
            var UserId = _userService.GetUserId();

            return View("Index", _userService.GetUserSubscriptions(UserId));
        }
    }
}
