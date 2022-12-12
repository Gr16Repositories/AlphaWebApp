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
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AlphaWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubscriptionTypeService _subscriptionTypeService;
        //RoleManager<IdentityRole> _roleManager;


        public AdminController(ICategoryService categoryService , 
                                ISubscriptionTypeService subscriptionTypeService
                                //RoleManager<IdentityRole> roleManager
                                )
        {
            _categoryService = categoryService;
            _subscriptionTypeService = subscriptionTypeService;
            //_roleManager = roleManager;
        }

        // This method has a view to admin page
        public IActionResult Index()
        {
            return View();
        }


        // GET: Admin
        public async Task<IActionResult> IndexCategory()
        {
            if(await Task.Run(() => _categoryService.GetAllCategory().ToList().Any()))
            {
                return View(await Task.Run(() => _categoryService.GetAllCategory().ToList()));
            }
            else
            {
                return RedirectToAction("CreateCategory");
            }
        }

        
        // GET: Admin/Create
        public IActionResult CreateCategory()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                await Task.Run(() => _categoryService.AddCategory(category));
                return RedirectToAction(nameof(IndexCategory));
            }
            return View(category);
        }



        // GET: Admin/Edit/5
        public async Task<IActionResult> EditCategory(int? id)
        {
            if (id == null || _categoryService.GetAllCategory() == null)
            {
                return NotFound();
            }
            var Category = await Task.Run(() => _categoryService.GetCategoryById(id));
            if (Category == null)
            {
                return NotFound();
            }
            return View(Category);
        }

        //// POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(int? id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await Task.Run(() =>
                    {
                        _categoryService.UpdateCategory(id, category);
                    });
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
                return RedirectToAction(nameof(IndexCategory));
            }
            return View(category);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null || _categoryService.GetCategoryById(id)== null)
            {
                return NotFound();
            }

            
            var category = await Task.Run(() => _categoryService.GetCategoryById(id));
            if (category == null)
            {
                return RedirectToAction("IndexCategory");
            }
            else
            {
                return View(category);
            }
        }

        //// POST: Admin/Delete/5
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_categoryService.GetCategoryById(id) == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
            }
            var category = await Task.Run(() => _categoryService.GetCategoryById(id));
            if (category != null)
                await Task.Run(() =>
            {
                _categoryService.DeleteCategory(id);
            });
            return RedirectToAction(nameof(IndexCategory));
        }

        private bool CategoryExists(int id)
        {
            return  _categoryService.GetAllCategory().Any(e => e.Id == id);
        }


        // Code for SubscriptionType CRUD

        // GET: SubscriptionTypes
        public async Task<IActionResult> IndexSubscriptionType()
        {
            if (_subscriptionTypeService.GetAllSubscriptionType().ToList().Count > 0)
            {
                return View(await Task.Run(() => _subscriptionTypeService.GetAllSubscriptionType().ToList()));
            }
            else
            {
                return RedirectToAction("CreateSubscriptionType");
            }
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
        public async Task<IActionResult> CreateSubscriptionType( SubscriptionType subscriptionType)
        {
            if (ModelState.IsValid)
            {
                await Task.Run(() => _subscriptionTypeService.AddSubscriptionType(subscriptionType));
                return RedirectToAction(nameof(IndexSubscriptionType));
            }
            return View(subscriptionType);
        }

        // GET: SubscriptionTypes/Edit/5
        public async Task<IActionResult> EditSubscriptionType(int? id)
        {
            if (id == null || _subscriptionTypeService.GetAllSubscriptionType == null)
            {
                return NotFound();
            }

            var subscriptionType = await Task.Run(() => _subscriptionTypeService.GetSubscriptionTypeById(id));
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
        public async Task<IActionResult> EditSubscriptionType(int id,  SubscriptionType subscriptionType)
        {
            if (id != subscriptionType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await Task.Run(() =>
                    {
                        _subscriptionTypeService.UpdateSubscriptionType(id, subscriptionType);
                    });
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
                return RedirectToAction(nameof(IndexSubscriptionType));
            }
            return View(subscriptionType);
        }

        // GET: SubscriptionTypes/Delete/5
        public async Task<IActionResult> DeleteSubscriptionType(int? id)
        {
            if (id == null || _subscriptionTypeService.GetSubscriptionTypeById(id) == null)
            {
                return NotFound();
            }

            var subscriptionType = await Task.Run(() => _subscriptionTypeService.GetSubscriptionTypeById(id));
            if (subscriptionType == null)
            {
                return RedirectToAction("IndexSubscriptionType");
            }
            else
            {
                return View(subscriptionType);
            }
        }

        // POST: SubscriptionTypes/Delete/5
        [HttpPost, ActionName("DeleteSubscriptionType")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedSubscriptionType(int id)
        {
            if (_subscriptionTypeService.GetSubscriptionTypeById(id) == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SubscriptionTypes'  is null.");
            }
            var subscriptionType = await Task.Run(() => _subscriptionTypeService.GetSubscriptionTypeById(id));
            if (subscriptionType != null)
                await Task.Run(() =>
                {
                    _subscriptionTypeService.DeleteSubscriptionType(id);
                });

            return RedirectToAction(nameof(IndexSubscriptionType));
        }

        private bool SubscriptionTypeExists(int id)
        {
            return _subscriptionTypeService.GetAllSubscriptionType().Any(e => e.Id == id);
        }


        //This section give the admin the previlge to show and create delete roles to users
        //public IActionResult IndexRols()
        //{
        //    var roles = _roleManager.Roles.ToList();
        //    return View(roles);
        //}


        //public IActionResult CreateRole()
        //{
        //    return View(new IdentityRole());
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateRole(IdentityRole role)
        //{
        //    await _roleManager.CreateAsync(role);
        //    return RedirectToAction("Index");
        //}
    }
}
