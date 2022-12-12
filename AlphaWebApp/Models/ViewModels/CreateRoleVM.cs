using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AlphaWebApp.Models.ViewModels
{
    public class CreateRoleVM
    {
        [Required]
        public string RoleName { get; set; }
    }
}
