using System.ComponentModel.DataAnnotations;

namespace AlphaWebApp.Models
{
    public class Article
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime DateStamp { get; set; }
        [Required]
        public string LinkText { get; set; }
        [Required]
        public string Headline { get; set; }
        [Required]
        public string ContentSummary { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int Views { get; set; }
        [Required]
        public  int  Likes { get; set; }
        [Required]
        public string  ImageLink { get; set; }

        public IFormFile CoverImage { get; set; }

        public Category Category { get; set; }

        public virtual ICollection<Category> CategorieList { get; set; }

    }
}
