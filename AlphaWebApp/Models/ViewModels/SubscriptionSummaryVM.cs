using Microsoft.EntityFrameworkCore.Metadata;

namespace AlphaWebApp.Models.ViewModels
{
    public class SubscriptionSummaryVM
    {
        public int SubscriptionId { get; set; }
        public string SubscriberName { get; set; }
        public string SubscriberEmail { get; set;}
        public string SubscriptionTypeName { get; set; }
        public DateTime SubscriptionExpiryDate { get; set; }
        public decimal SubscriptionPrice { get; set; }
        //some properties in order to send contact us email
        public string Name { get; set; } = null;
        public string Email { get; set; } = null;
        public string Message { get; set; } = null;

    }
}
