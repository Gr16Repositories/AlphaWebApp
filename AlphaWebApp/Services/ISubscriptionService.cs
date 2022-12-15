using AlphaWebApp.Models;

namespace AlphaWebApp.Services
{
    public interface ISubscriptionService
    {
        Task<List<SubscriptionType>> GetAllSubscriptiontypeList();
    }
}
