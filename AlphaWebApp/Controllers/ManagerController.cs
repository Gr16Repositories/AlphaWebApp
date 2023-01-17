using AlphaWebApp.Models;
using AlphaWebApp.Models.ViewModels;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AlphaWebApp.Controllers
{
    //[Authorize(Roles = ("Manager"))]
    public class ManagerController : Controller
    {
        private readonly IUserService _userService;

        public ManagerController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            
            return View(_userService.GetAllRoles());
        }


        public IActionResult UsersRoles()
        {
            var users = _userService.GetallUsers();
            foreach(var user in users)
            {
                user.
            }
            return View();
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
            return await Task.Run(()=>View());
        }


        public async Task<IActionResult> AddEmailToRole(string id)
        {
            CreateRoleVM roleId = new CreateRoleVM() { RoleId = id };
            return await Task.Run(() => View(roleId));
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
