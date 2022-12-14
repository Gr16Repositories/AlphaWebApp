using AlphaWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AlphaWebApp.Services
{
    public interface IUserService
    {
        List<IdentityRole> GetAllRoles();

        Task<IdentityResult> AddRole(IdentityRole role);
       
        Task<IdentityResult> RemoveRole(string id);
        Task<IdentityResult> AddRoleToUser(string roleId, string userEmail);

    }
}
