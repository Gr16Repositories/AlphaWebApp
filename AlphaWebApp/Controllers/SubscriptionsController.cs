using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlphaWebApp.Data;
using AlphaWebApp.Models;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using AlphaWebApp.Models.ViewModels;

namespace AlphaWebApp.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IUserService _userService;
        private readonly ILogger<SubscriptionsController> _logger;
        private readonly IEmailService _emailService;

        public SubscriptionsController(ISubscriptionService subscriptionService,
                                        IUserService userService,
                                        ILogger<SubscriptionsController> logger,
                                        IEmailService emailService)
        {
            _subscriptionService = subscriptionService;
            _userService = userService;
            _logger = logger;
            _emailService = emailService;
        }

        [Authorize]
        // GET: Subscriptions
        public async Task<IActionResult> Index()
        {
            return View( await Task.Run(()=> _subscriptionService.GetAllSubscriptions()));
        }

        
        //starts when any user click on subscribe button, gives list of subscription typs
        public async Task<IActionResult> GetSubscriptionTypsList()
        {
            return View(await _subscriptionService.GetAllSubscriptiontypeList());
        }

        
        [Authorize]
        // Make paypal payment
        public async Task<IActionResult> MakePayment(int id)
        {
            // Intial payment, no payment
            var paymentComplete = false;
            SubscriptionVM newSub = await Task.Run(()=> _subscriptionService.AddSubscripton(id, paymentComplete));
            //return  await Task.Run(()=> RedirectToAction("Create",newSub));
            return View(newSub);
        }


        [Authorize]
        // GET: Subscriptions/Create
        public async Task<IActionResult> Create(int id)
        {
            // when payment success so now Create Subscription and save it in database
            var paymentComplete = true;
            SubscriptionVM newSub = await Task.Run(() => _subscriptionService.AddSubscripton(id, paymentComplete));
            Subscription subscription = await _subscriptionService.SaveSubscripton(newSub);
            return RedirectToAction("SendSubscriptionEmail", new {id = subscription.Id });
        }


        public IActionResult SendSubscriptionEmail(int id)
        {
            Subscription subscription = _subscriptionService.GetSubscriptionById(id);
            SubscriptionSummaryVM summary = new SubscriptionSummaryVM();
            summary.SubscriptionId = subscription.Id;
            summary.SubscriberName = subscription.User.FirstName + " " + subscription.User.LastName;
            summary.SubscriberEmail = subscription.User.Email;
            summary.SubscriptionTypeName = subscription.SubscriptionType.TypeName;
            summary.SubscriptionPrice = subscription.Price;
            //Subscribtion will end after one month
            summary.SubscriptionExpiryDate = subscription.Created.AddMonths(1);
            var result = SendConfirmation(summary);
            var resultTuple = new Tuple<string>(result);
            return View(resultTuple);
        }


        public string SendConfirmation(SubscriptionSummaryVM summary)
        {
            return _emailService.SendSubscriptionEmail(summary).Result;
        }


        // GET: Subscriptions/Details/5
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _subscriptionService.GetAllSubscriptions() == null)
            {
                return NotFound();
            }
            var subscription = await Task.Run(() => _subscriptionService.GetSubscriptionById(id));
            if (subscription == null)
            {
                return NotFound();
            }
            return View(subscription);
        }


        // GET: Subscriptions/Edit/5
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _subscriptionService.GetAllSubscriptions() == null)
            {
                return NotFound();
            }

            var subscription = await Task.Run(() => _subscriptionService.GetSubscriptionById(id));
            if (subscription == null)
            {
                return NotFound();
            }
            ViewData["SubscriptionTypeId"] = new SelectList(await _subscriptionService.GetAllSubscriptiontypeList(), "Id", "TypeName", subscription.SubscriptionTypeId);
            return View(subscription);
        }

        // POST: Subscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Subscription subscription)
        {
            var userId = subscription.UserId;
            if (id != subscription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _subscriptionService.UpdateSubscription(id, subscription);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriptionExists(subscription.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubscriptionTypeId"] = new SelectList(await _subscriptionService.GetAllSubscriptiontypeList(), "Id", "TypeName", subscription.SubscriptionTypeId);
            return View(subscription);
        }



        // GET: Subscriptions/Delete/5
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _subscriptionService.GetAllSubscriptions() == null)
            {
                return NotFound();
            }
            var subscription = await Task.Run(()=> _subscriptionService.GetSubscriptionById(id));
            if (subscription == null)
            {
                return NotFound();
            }
            return View(subscription);
        }

        // POST: Subscriptions/Delete/5
        [Authorize(Roles = ("Admin"))]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_subscriptionService.GetAllSubscriptions() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Subscriptions'  is null.");
            }
            var subscription = await Task.Run(() => _subscriptionService.GetSubscriptionById(id));
            if (subscription != null)
            {
                _subscriptionService.RemoveSubscription(id);
            }
            
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = ("Admin"))]
        private bool SubscriptionExists(int id)
        {
            if(_subscriptionService.GetSubscriptionById(id) != null)
            {
                return true;
            }
            else
            {
                return false ; 
            }
            //var test = _context.Subscriptions.Any(e => e.Id == id);
            //return _context.Subscriptions.Any(e => e.Id == id).Any(e => e.Id == id);
            //return _subscriptionService.GetAllSubscriptions().Any(e => e.Id == id);
        }

        // How to make a subscription active under some time.
        // How to send Email when subscritpion is expire.
        // How to make specification for subscriber?

    }
}
