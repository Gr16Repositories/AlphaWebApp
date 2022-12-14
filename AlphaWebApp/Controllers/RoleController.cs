using AlphaWebApp.Models;
using AlphaWebApp.Models.ViewModels;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers
{
    public class RoleController : Controller
    {
        private readonly IUserService _userService;

        public RoleController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var test = _userService.GetAllRoles();
            return View(_userService.GetAllRoles());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await Task.Run(() => _userService.AddRole(role));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteRole(string id)
        {

            if (ModelState.IsValid)
            {
                IdentityResult result = await Task.Run(() => _userService.RemoveRole(id));

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddRoleToUser(string id)
        {
            return View();
        }


        public async Task<IActionResult> AddEmailToRole(string id)
        {
            CreateRoleVM roleId = new CreateRoleVM() { RoleId = id };
            return View(roleId);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmailToRole(string Email, string id)
        {

            if (ModelState.IsValid)
            {
                IdentityResult result = await Task.Run(() => _userService.AddRoleToUser(id, Email));

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
