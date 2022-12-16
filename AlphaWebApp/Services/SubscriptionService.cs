using AlphaWebApp.Data;
using AlphaWebApp.Models;
using System.Runtime.CompilerServices;

namespace AlphaWebApp.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ApplicationDbContext _db;

        public SubscriptionService(ApplicationDbContext db)
        {
            _db = db;
        }

        //starts when any user click on subscribe button, gives list of subscription typs
        public async Task<List<SubscriptionType>> GetAllSubscriptiontypeList()
        {
            return await Task.Run(() => _db.SubscriptionTypes.ToList());
        }

    }
}
