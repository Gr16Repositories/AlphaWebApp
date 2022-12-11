using AlphaWebApp.Data;
using AlphaWebApp.Models;

namespace AlphaWebApp.Services
{
    public class SubscriptionTypeService : ISubscriptionTypeService
    {

        private readonly ApplicationDbContext _db;

        public SubscriptionTypeService(ApplicationDbContext db)
        {
            _db = db;
        }


        public List<SubscriptionType> GetAllSubscriptionType()
        {
            return _db.SubscriptionTypes.ToList();
        }

        public void AddSubscriptionType(SubscriptionType newSubscriptionType)
        {
            _db.Add(newSubscriptionType);
            _db.SaveChanges();
        }

        public void UpdateSubscriptionType(int id, SubscriptionType newSubscriptionType)
        {
            if (newSubscriptionType != null)
            {
                _db.SubscriptionTypes.Update(newSubscriptionType);
                _db.SaveChanges();
            }
        }

        public SubscriptionType GetSubscriptionTypeById(int? id)
        {
            SubscriptionType specificSubscriptionTypeById = _db.SubscriptionTypes.FirstOrDefault(x => x.Id == id);
            return specificSubscriptionTypeById;
        }

        public void DeleteSubscriptionType(int? id)
        {
            SubscriptionType supscriptionDetails = _db.SubscriptionTypes.Find(id);
            if (supscriptionDetails != null)
            {
                _db.SubscriptionTypes.Remove(supscriptionDetails);
                _db.SaveChanges();
            }
        }

    }
}
