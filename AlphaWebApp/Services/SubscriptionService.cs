using AlphaWebApp.Data;
using AlphaWebApp.Models;
using AlphaWebApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace AlphaWebApp.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ApplicationDbContext _db;
        private readonly IUserService _userService;

        public SubscriptionService(ApplicationDbContext db, IUserService userservice)
        {
            _userService= userservice;
            _db = db;
        }

        //starts when any user click on subscribe button, gives list of subscription typs
        public async Task<List<SubscriptionType>> GetAllSubscriptiontypeList()
        {
            return await Task.Run(() => _db.SubscriptionTypes.ToList());
        }


        public List<Subscription> GetAllSubscriptions()
        {
            return _db.Subscriptions
                    //.Include(s => s.SubscriptionType)
                    .ToList();
        }



        public Subscription GetSubscriptionById(int? id)
        {
            Subscription specificSubscriptionById = _db.Subscriptions
                //.Include(s => s.SubscriptionType)
                .FirstOrDefault(x => x.Id == id);
            return specificSubscriptionById;
        }


        public async Task<SubscriptionVM> AddSubscripton(int SubscriptionTypeId, bool paymentComplete)
        {
            SubscriptionVM newSub = new SubscriptionVM
            {
                PaymentComplete = paymentComplete,
                Price = _db.SubscriptionTypes.Find(SubscriptionTypeId).Price,
                UserId = _userService.GetUserId(),
                SubscriptionTypeId = SubscriptionTypeId,
            };

            return await Task.Run(() => newSub);
        }

        public async Task<Subscription> SaveSubscripton(SubscriptionVM newSub)
        {
            Subscription subscription = new Subscription()
            {
                PaymentComplete = newSub.PaymentComplete,
                Price = newSub.Price,
                UserId = newSub.UserId,
                SubscriptionTypeId = newSub.SubscriptionTypeId
            };
            _db.Subscriptions.Add(subscription);
            _db.SaveChanges();
            return await Task.Run(() => subscription);
        }

        public void UpdateSubscription(int id, Subscription subscription)
        {
            _db.Update(subscription);
            _db.SaveChanges();
        }


        public void RemoveSubscription(int id)
        {
            _db.Subscriptions.Remove(GetSubscriptionById(id));
            _db.SaveChanges();
        }
    }
}
