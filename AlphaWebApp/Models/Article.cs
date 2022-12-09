using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaWebApp.Models
{
    public class Article
    {
        
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime DateStamp { get; set; }
        [Required]
        public string LinkText { get; set; }
        [Required]
        public string HeadLine { get; set; }
        [Required]
        public string ContentSummary { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int Views { get; set; }
        [Required]
        public int Likes { get; set; }
        [Required]
        public Uri ImageLink { get; set; }

        [NotMapped]
        public IFormFile CoverImage { get; set; }

        //[ForeignKey("Category")]
        public int? CategoryId { get; set; } 
        public virtual Category Category { get; set; }

    }
}
