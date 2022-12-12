﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }



        //private async Task CreateRolesandUsers()
        //{
        //    bool x = await _roleManager.RoleExistsAsync("Admin");
        //    if (!x)
        //    {
        //        // first we create Admin rool    
        //        var role = new IdentityRole();
        //        role.Name = "Admin";
        //        await _roleManager.CreateAsync(role);

        //        //Here we create a Admin super user who will maintain the website                   

        //        var user = new ApplicationUser();
        //        user.UserName = "default";
        //        user.Email = "default@default.com";

        //        string userPWD = "password";

        //        IdentityResult chkUser = await _userManager.CreateAsync(user, userPWD);

        //        //Add default User to Role Admin    
        //        if (chkUser.Succeeded)
        //        {
        //            var result1 = await _userManager.AddToRoleAsync(user, "Admin");
        //        }
        //    }

        //    // creating Creating Manager role     
        //    x = await _roleManager.RoleExistsAsync("Manager");
        //    if (!x)
        //    {
        //        var role = new IdentityRole();
        //        role.Name = "Manager";
        //        await _roleManager.CreateAsync(role);
        //    }

        //    // creating Creating Employee role     
        //    x = await _roleManager.RoleExistsAsync("Editor");
        //    if (!x)
        //    {
        //        var role = new IdentityRole();
        //        role.Name = "Editor";
        //        await _roleManager.CreateAsync(role);
        //    }
        //}


    }
}
