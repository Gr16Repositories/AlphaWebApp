using System.ComponentModel.DataAnnotations;


namespace AlphaWebApp.Models
{
    public class SubscriptionType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public subscriptionTypeName TypeName { get; set; }

        [Required]
        public string Description { get; set; }
        
        public enum subscriptionTypeName { Free ,Basic ,Standerd ,Premium }

        
        public virtual ICollection<Subscription> Supscriptions { get; set; }
    }
}
