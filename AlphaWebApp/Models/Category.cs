using System.ComponentModel.DataAnnotations;

namespace AlphaWebApp.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public Category()
        {

        }
    }
}
