using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AlphaWebApp.Models.ViewModels
{
    public class EditArticleVM :AddArticleVM
    {      
        public Uri ExisingImageLink { get; set; }       
    }
}
