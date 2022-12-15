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

namespace AlphaWebApp.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IUserService _userService;
        private readonly ILogger<SubscriptionsController> _logger;

        public SubscriptionsController(ApplicationDbContext context,
                                        ISubscriptionService subscriptionService,
                                        IUserService userService,
                                        ILogger<SubscriptionsController> logger)
        {
            _context = context;
            _subscriptionService = subscriptionService;
            _userService = userService;
            _logger = logger;
        }

        [Authorize]
        // GET: Subscriptions
        public async Task<IActionResult> Index()
        {
            //check if user logged in or not.
            bool IsloggedIn = _userService.IsLoggeIn();
            if (IsloggedIn)
            {
                string userId = _userService.GetUserId();
            }
            var applicationDbContext = _context.Subscriptions.Include(s => s.SubscriptionType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Subscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Subscriptions == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscriptions
                .Include(s => s.SubscriptionType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }
        
        [Authorize]
        // GET: Subscriptions/Create
        public IActionResult Create()
        {
            ViewData["SubscriptionTypeId"] = new SelectList(_context.SubscriptionTypes, "Id", "TypeName");
            return View();
        }

        // POST: Subscriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Created,PaymentComplete,UserId,SubscriptionTypeId")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subscription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubscriptionTypeId"] = new SelectList(_context.SubscriptionTypes, "Id", "TypeName", subscription.SubscriptionTypeId);
            return View(subscription);
        }

        // GET: Subscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subscriptions == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }
            ViewData["SubscriptionTypeId"] = new SelectList(_context.SubscriptionTypes, "Id", "TypeName", subscription.SubscriptionTypeId);
            return View(subscription);
        }

        // POST: Subscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,Created,PaymentComplete,UserId,SubscriptionTypeId")] Subscription subscription)
        {
            if (id != subscription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscription);
                    await _context.SaveChangesAsync();
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
            ViewData["SubscriptionTypeId"] = new SelectList(_context.SubscriptionTypes, "Id", "TypeName", subscription.SubscriptionTypeId);
            return View(subscription);
        }

        // GET: Subscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subscriptions == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscriptions
                .Include(s => s.SubscriptionType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }

        // POST: Subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subscriptions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Subscriptions'  is null.");
            }
            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriptionExists(int id)
        {
          return _context.Subscriptions.Any(e => e.Id == id);
        }
    }
}
