using AlphaWebApp.Models.ViewModels;

namespace AlphaWebApp.Services
{
    public interface IEmailService
    {
        Task<string> SendSubscriptionEmail(SubscriptionSummaryVM newSummary);
        Task<string> SendNewsletterEmail(PersonalizedNewsletterVM newNewsletter);
    }
}

