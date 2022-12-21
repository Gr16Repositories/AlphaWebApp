using System.ComponentModel.DataAnnotations;

namespace AlphaWebApp.Models.ViewModels
{
    public class SubscriptionVM
    {
        [Required]
        public decimal Price { get; set; }

        public string UserId { get; set; }

        public int SubscriptionTypeId { get; set; }

        public bool PaymentComplete { get; set; }

        public int Period { get; set; }

    }
}
