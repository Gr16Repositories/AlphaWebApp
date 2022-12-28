using AlphaWebApp.Data;
using AlphaWebApp.Models;
using AlphaWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace AlphaWebApp.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ApplicationDbContext _db;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public SubscriptionService(ApplicationDbContext db, IUserService userservice, UserManager<User> userManager)
        {
            _userService= userservice;
            _userManager = userManager;
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
                Period = _db.SubscriptionTypes.Find(SubscriptionTypeId).Period,
                CreatedAt = DateTime.Now
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
                SubscriptionTypeId = newSub.SubscriptionTypeId,
                Active = true,
                ExpireAt = newSub.CreatedAt.AddMonths(newSub.Period)
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

        //give me subscription for specific  user - use it in _loginPartial
        public Subscription GetActiveSubscription(ClaimsPrincipal claimsPrincipal)
        {
            var userId = _userManager.GetUserId(claimsPrincipal);
            var sub = _userService.GetUserSubscriptions(userId);
            var activeSub = sub.FirstOrDefault(s => s.Active);
            return activeSub;
        }

        //has user have an active subscripion - use it in _loginPartial
        public bool HasSubscription(ClaimsPrincipal claimsPrincipal)
        {
            return GetActiveSubscription(claimsPrincipal) != null;
        }

    }
}
