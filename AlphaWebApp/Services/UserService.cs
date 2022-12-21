using AlphaWebApp.Models;
using AlphaWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Versioning;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Claims;
using Azure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using NuGet.Protocol.Plugins;

namespace AlphaWebApp.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _httpContext;

        public UserService(ApplicationDbContext db,
                            UserManager<User>userManager,
                            RoleManager<IdentityRole> roleManager,
                            IHttpContextAccessor httpContext)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _httpContext = httpContext;
        }

        public List<IdentityRole> GetAllRoles()
        {
            return _roleManager.Roles.ToList();
        }

        public  async Task<IdentityResult> AddRole(IdentityRole role)
        {
           return await _roleManager.CreateAsync(role);
        }

        public async Task<IdentityResult> RemoveRole(string id)
        {
            IdentityRole roleToDelete = await _roleManager.FindByIdAsync(id);
            if (roleToDelete == null)
            {
                return null;
            }
            return await _roleManager.DeleteAsync(roleToDelete);
        }

        public async Task<IdentityResult> AddRoleToUser(string roleId, string userEmail)
        {
            User user = _db.Users.FirstOrDefault(u => u.Email == userEmail);
            IdentityRole roleToAssigne = await _roleManager.FindByIdAsync(roleId);

            return await _userManager.AddToRoleAsync(user, roleToAssigne.Name);
        }

        //Check if the user is logged in or not
        public bool IsLoggeIn()
        {
            return _httpContext.HttpContext.User.Identity.IsAuthenticated;
        }

        // Gives a User Id where you call it in the project, Condition! you have to call it from Authorized method
        public string GetUserId()
        {
            var userId = _httpContext.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId;           
        }

        //Give me all subscriptions related to this user
        public List<Subscription> GetUserSubscriptions(string UserId)
        {
            List<Subscription> UserSubscriptions = _db.Subscriptions.Where(s => s.UserId == UserId).ToList();
            return UserSubscriptions;
        }

        

    }
}
