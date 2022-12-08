using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace AlphaWebApp.Models.ViewModels
{
    public class AddArticleVM
    {

        public AddArticleVM()
        {
            Categories = new List<SelectListItem>();
        }

        [Required]
        [Display(Name = "Text in Link")]
        public string LinkText { get; set; }
        [Required] 
        public string Title { get; set; }
        public string HeadLine { get; set; }
        [StringLength(100), Required]
        public string ContentSummary { get; set; }
        [Required]
        public string Content { get; set; }
        
        [Required]
        [Display(Name = "CategoryId")]
        public string CategoryId { get; set; }
        public List<SelectListItem>  Categories { get; set; }

        public string FileName { get; set; }
        
        public IFormFile File { get; set; } 

    }
}
