using AlphaWebApp.Models;
using AlphaWebApp.Models.ViewModels;

namespace AlphaWebApp.Services
{
    public interface ISubscriptionService
    {
        Task<List<SubscriptionType>> GetAllSubscriptiontypeList();
        List<Subscription> GetAllSubscriptions();
        Subscription GetSubscriptionById(int? id);
        Task<SubscriptionVM> AddSubscripton(int SubscriptionTypeId, bool paymentComplete);

        Task<Subscription> SaveSubscripton(SubscriptionVM newSub);

        void UpdateSubscription(int id, Subscription subscription);

        void RemoveSubscription(int id);
    }
}
