using AlphaWebApp.Models;
using AlphaWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Versioning;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AlphaWebApp.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(ApplicationDbContext db, UserManager<User>
                        userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
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

    }
}
