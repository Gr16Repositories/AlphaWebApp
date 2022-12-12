using AlphaWebApp.Models;

namespace AlphaWebApp.Services
{
    public interface ISubscriptionTypeService
    {

        List<SubscriptionType> GetAllSubscriptionType();
        void AddSubscriptionType(SubscriptionType newSubscriptionType);

        void UpdateSubscriptionType(int id, SubscriptionType newSubscriptionType);

        SubscriptionType GetSubscriptionTypeById(int? id);

        void DeleteSubscriptionType(int? id);
    }
}
