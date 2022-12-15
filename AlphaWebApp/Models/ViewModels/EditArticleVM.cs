using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AlphaWebApp.Models.ViewModels
{
    public class EditArticleVM :AddArticleVM
    {       

        //[Required]
        //[DisplayName("File Name")]
        //public string FileName { get; set; }

        //public IFormFile File { get; set; }

        //[Required]
        //public Uri ImageLink { get; set; }

        public Uri ExisingImageLink { get; set; }

       
    }
}
