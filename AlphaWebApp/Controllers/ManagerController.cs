using AlphaWebApp.Models;
using AlphaWebApp.Models.ViewModels;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsAPI.Models;
using System.Data;

namespace AlphaWebApp.Controllers
{
    [Authorize(Roles = ("Manager"))]
    public class ManagerController : Controller
    {
        private readonly IUserService _userService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public ManagerController(IUserService userService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _userService = userService;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            
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


        // In order to add users to roles and vice versa
        [Authorize]
        public async Task<IActionResult> Update(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            List<User> members = new List<User>();
            List<User> nonMembers = new List<User>();
            foreach (User user in _userService.GetallUsers())
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return View(new RoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }


        [HttpPost]
        public async Task<IActionResult> Update(RoleModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    User user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    User user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await Update(model.RoleId);
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


        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}
