using MessagePack;
using Microsoft.Build.Framework;

namespace AlphaWebApp.Models
{
    public class Category
    {
        
        [Required]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }

        public virtual ICollection<Article> Articleslist { get; set; }

        public Category()
        {
            List<Article> Articleslist = new List<Article>();
        }
    }
}
