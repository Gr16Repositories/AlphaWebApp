using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace AlphaWebApp.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Pirce { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public bool PaymentComplete { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public SubscriptionType SubscriptionTypeId { get; set; }

        public virtual SubscriptionType SubscriptionType { get; set; }
        //public  virtual ICollection<User> UsersList { get; set; }
    }
}
