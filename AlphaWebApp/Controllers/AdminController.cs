using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlphaWebApp.Data;
using AlphaWebApp.Models;

namespace AlphaWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> IndexCategory()
        {
              return View(await _context.Categories.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> DetailsCategory(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/Create
        public IActionResult CreateCategory()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory([Bind("Id,name")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> EditCategory(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(int id, [Bind("Id,name")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedCategory(int id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
            }
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
          return _context.Categories.Any(e => e.Id == id);
        }


        // Code for SubscriptionType CRUD

        // GET: SubscriptionTypes
        public async Task<IActionResult> IndexSubscriptionType()
        {
            return View(await _context.SubscriptionTypes.ToListAsync());
        }

        // GET: SubscriptionTypes/Details/5
        public async Task<IActionResult> DetailsSubscriptionType(int? id)
        {
            if (id == null || _context.SubscriptionTypes == null)
            {
                return NotFound();
            }

            var subscriptionType = await _context.SubscriptionTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscriptionType == null)
            {
                return NotFound();
            }

            return View(subscriptionType);
        }

        // GET: SubscriptionTypes/Create
        public IActionResult CreateSubscriptionType()
        {
            return View();
        }

        // POST: SubscriptionTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubscriptionType([Bind("Id,TypeName,Description")] SubscriptionType subscriptionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subscriptionType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subscriptionType);
        }

        // GET: SubscriptionTypes/Edit/5
        public async Task<IActionResult> EditSubscriptionType(int? id)
        {
            if (id == null || _context.SubscriptionTypes == null)
            {
                return NotFound();
            }

            var subscriptionType = await _context.SubscriptionTypes.FindAsync(id);
            if (subscriptionType == null)
            {
                return NotFound();
            }
            return View(subscriptionType);
        }

        // POST: SubscriptionTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSubscriptionType(int id, [Bind("Id,TypeName,Description")] SubscriptionType subscriptionType)
        {
            if (id != subscriptionType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscriptionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriptionTypeExists(subscriptionType.Id))
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
            return View(subscriptionType);
        }

        // GET: SubscriptionTypes/Delete/5
        public async Task<IActionResult> DeleteSubscriptionType(int? id)
        {
            if (id == null || _context.SubscriptionTypes == null)
            {
                return NotFound();
            }

            var subscriptionType = await _context.SubscriptionTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscriptionType == null)
            {
                return NotFound();
            }

            return View(subscriptionType);
        }

        // POST: SubscriptionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedSubscriptionType(int id)
        {
            if (_context.SubscriptionTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SubscriptionTypes'  is null.");
            }
            var subscriptionType = await _context.SubscriptionTypes.FindAsync(id);
            if (subscriptionType != null)
            {
                _context.SubscriptionTypes.Remove(subscriptionType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriptionTypeExists(int id)
        {
            return _context.SubscriptionTypes.Any(e => e.Id == id);
        }
    }
}
