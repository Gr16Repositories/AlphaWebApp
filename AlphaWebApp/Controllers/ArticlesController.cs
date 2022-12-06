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

namespace AlphaWebApp.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;

        public ArticlesController(ApplicationDbContext db,IArticleService articleService)
        {
            _db = db;
            _articleService = articleService;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            //List<Article> listOfArticles = await Task.Run(() => _articleService.GetAllArticles().ToList());
            //return View(listOfArticles);
            return View();
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
            return View();
        }

        // POST: Articles/Create      
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateStamp,LinkText,Headline,ContentSummary,Content,Views,Likes,ImageLink")] Article article)
        {
            if (ModelState.IsValid)
            {
               // article.CoverImage = FileUpload(article);
                await Task.Run(() => _articleService.AddArticle(article));
                return RedirectToAction(nameof(Index));
            }
            return View(article);
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
        private Article FileUpload(Article article)
        {
            string uniqueFileName = null;
            string uploadFilesFolder = Path.Combine(Directory.GetCurrentDirectory(), "images");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + article.CoverImage.FileName;
            string filePath = Path.Combine(uploadFilesFolder, uniqueFileName);
            article.CoverImage.CopyTo(new FileStream(filePath, FileMode.Create));
            return article;
        }
    }
}
