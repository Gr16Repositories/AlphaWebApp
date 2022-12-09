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
using Microsoft.Extensions.Hosting.Internal;
using AlphaWebApp.Models.ViewModels;

namespace AlphaWebApp.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;
        private readonly IStorageService _storageService;

        public ArticlesController(ApplicationDbContext db,
            IArticleService articleService,
            IStorageService storageService)
        {
            _db = db;
            _articleService = articleService;
            _storageService = storageService;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            List<Article> listOfArticles = await Task.Run(() => _articleService.GetAllArticles().ToList());
           return View(listOfArticles);
            //return View();

        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int id)
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

        // GET: Articles/Create
        public IActionResult Create()
        {
            AddArticleVM newArticle = new();
            // Should change - fetch Categories from db table
            // newArticle.Categories.Add(new SelectListItem {_articleService.GetCategories(), "Value", "Text"});
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
            if(ModelState.IsValid)
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
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _articleService.GetAllArticles() == null)
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

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateStamp,LinkText,Headline,ContentSummary,Content,Views,Likes,ImageLink")] Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await Task.Run(() =>
                    {
                        _articleService.UpdateArticle(id, article);
                    });
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
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int id)
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
          
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
          return _db.Articles.Any(e => e.Id == id);
        } 
    }
}
