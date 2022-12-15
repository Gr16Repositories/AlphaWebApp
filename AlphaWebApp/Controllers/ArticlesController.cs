﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlphaWebApp.Data;
using AlphaWebApp.Models;
using AlphaWebApp.Services;
using Microsoft.Extensions.Hosting.Internal;
using AlphaWebApp.Models.ViewModels;
using AutoMapper;

namespace AlphaWebApp.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;
        private readonly IStorageService _storageService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ArticlesController(ApplicationDbContext db,
            IArticleService articleService,
            IStorageService storageService,
            IConfiguration configuration, IMapper mapper)
        {
            _db = db;
            _articleService = articleService;
            _storageService = storageService;
            _configuration = configuration;
            _mapper = mapper;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        { 
            List<Article> listOfArticles = await Task.Run(() => _articleService.GetAllArticles().ToList());
            if (listOfArticles != null)
                return View(listOfArticles);
            else
                return View();  
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _articleService.GetArticleById(id) == null)
            {
                return NotFound();
            }
            var article = await Task.Run(() => _articleService.GetArticleById(id));
            var categoryName = _articleService.GetCategoryById(Convert.ToInt32(article.CategoryId));
            if (article == null)           
                return NotFound();
           
            ViewBag.CategoryName = categoryName.name;
            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            AddArticleVM newArticle = new();
            // Should change - fetch Categories from db table
            // newArticle.Categories.Add(new SelectList {_articleService.GetCategories(), "Value", "Text"});
            newArticle.Categories.Add(new SelectListItem { Text = "Local", Value = "1" });
            newArticle.Categories.Add(new SelectListItem { Text = "Sweden", Value = "2" });
            newArticle.Categories.Add(new SelectListItem { Text = "World", Value = "3" });
            newArticle.Categories.Add(new SelectListItem { Text = "Weather", Value = "4" });
            newArticle.Categories.Add(new SelectListItem { Text = "Economy", Value = "5" });
            newArticle.Categories.Add(new SelectListItem { Text = "Sport", Value = "6" });

            return View(newArticle);
        }

        // POST: Articles/Create      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddArticleVM article)
        {
            if (ModelState.IsValid)
            {
                string folderPath = "wwwroot/images/articles" + "/" + article.CategoryId;
                string path = Path.Combine(Directory.GetCurrentDirectory(), folderPath);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileNameWithPath = Path.Combine(path, article.FileName);
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    article.File.CopyTo(stream);
                }
                // now the file is store locally we need to store it on Azure bolb
                string pathFile = article.CategoryId + "/" + article.File.FileName;
                Uri blobUri = _storageService.uploadBlob(pathFile);
                await Task.Run(() => _articleService.AddArticle(article, blobUri));
                TempData["success"] = "Article Created Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _articleService.GetAllArticles() == null)
            {
                return NotFound();
            }
            EditArticleVM editArticleVM = new();
            editArticleVM.Categories.Add(new SelectListItem { Text = "Local", Value = "1" });
            editArticleVM.Categories.Add(new SelectListItem { Text = "Sweden", Value = "2" });
            editArticleVM.Categories.Add(new SelectListItem { Text = "World", Value = "3" });
            editArticleVM.Categories.Add(new SelectListItem { Text = "Weather", Value = "4" });
            editArticleVM.Categories.Add(new SelectListItem { Text = "Economy", Value = "5" });
            editArticleVM.Categories.Add(new SelectListItem { Text = "Sport", Value = "6" });

            Article article = await Task.Run(() => _articleService.GetArticleById(id));
            EditArticleVM editArticle = new EditArticleVM
            {
                Categories = editArticleVM.Categories.ToList(),
                CategoryId = article.CategoryId.ToString(),
                DateStamp = article.DateStamp,
                LinkText = article.LinkText,
                HeadLine = article.HeadLine,
                ContentSummary = article.ContentSummary,
                Content = article.Content,
                ExisingImageLink = article.ImageLink,
                ImageLink = article.ImageLink,
                Views = article.Views,
                Likes = article.Likes
            };

            if (article == null)
            {
                return NotFound();
            }
            //return View(article);
            return View(editArticle);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditArticleVM article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }
            try
            {
                if (article.File != null)
                {
                    string folderPath = "wwwroot/images/articles" + "/" + article.CategoryId;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), folderPath);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string fileNameWithPath = Path.Combine(path, article.FileName);
                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        article.File.CopyTo(stream);
                    }
                    // now the file is store locally we need to store it on Azure bolb
                    string pathFile = article.CategoryId + "/" + article.File.FileName;
                    Uri blobUri = _storageService.uploadBlob(pathFile);
                    await Task.Run(() =>
                    {
                        _articleService.UpdateArticle(id, article, blobUri);
                    });
                }
                else
                {
                    await Task.Run(() =>
                    {
                        _articleService.UpdateArticleWithOutImage(id, article);
                    });
                }
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(article.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            TempData["success"] = "Article Updated Successfully";
            return RedirectToAction(nameof(Index));            
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _articleService.GetArticleById(id) == null)
            {
                return NotFound();
            }

            var article = await Task.Run(() => _articleService.GetArticleById(id));
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_articleService.GetArticleById(id) == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Article'  is null.");
            }
            var article = await Task.Run(() => _articleService.GetArticleById(id));
            if (article != null)
                await Task.Run(() =>
                {
                    _articleService.DeleteArticle(id);
                });
            TempData["success"] = "Article Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _db.Articles.Any(e => e.Id == id);
        }       
    }
}
