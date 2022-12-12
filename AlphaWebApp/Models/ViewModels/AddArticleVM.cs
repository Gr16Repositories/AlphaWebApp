using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace AlphaWebApp.Models.ViewModels
{
    public class AddArticleVM
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateStamp { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Text in Link")]
        public string LinkText { get; set; }

        [Required]
        public string HeadLine { get; set; }

        [DisplayName("Content Summary")]
        [StringLength(100), Required]
        public string ContentSummary { get; set; }

        [Required]
        public string Content { get; set; }
        
        [Required]
        [Display(Name = "Category")]
        public string CategoryId { get; set; }
        public List<SelectListItem>  Categories { get; set; }

        [Required]
        [DisplayName("File Name")]
        public string FileName { get; set; }
        
        public IFormFile File { get; set; }

        [Required]
        public Uri ImageLink { get; set; }

        public AddArticleVM()
        {
            Categories = new List<SelectListItem>();
        }
    }
}
