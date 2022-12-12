using System.ComponentModel.DataAnnotations;


namespace AlphaWebApp.Models
{
    public class SubscriptionType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TypeName { get; set; }

        [Required]
        public string Description { get; set; }
        
        public virtual ICollection<Subscription> Supscriptions { get; set; }
    }
}
