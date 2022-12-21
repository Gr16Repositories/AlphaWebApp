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
            article.Views++;
            if (article != null)
            {
                _articleService.SaveViewsToArticle(article.Id, article.Views);
            }
            ViewBag.CategoryName = categoryName.name;
            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            AddArticleVM newArticle = new();
            //Fetching the Categories from db and binding data to the Categories listbox.
            if (_articleService.GetCategories().Count > 0)
            {
                foreach (var item in _articleService.GetCategories())
                {
                    newArticle.Categories.Add(new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.name
                    });
                }
            }
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
            //Fetching the Categories from db and binding data to the Categories listbox.
            if (_articleService.GetCategories().Count > 0)
            {
                foreach (var item in _articleService.GetCategories())
                {
                    editArticleVM.Categories.Add(new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.name
                    });
                }
            }
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
                    // below code is written to delete the old image from folder and blob
                    Article oldArticle = await Task.Run(() => _articleService.GetArticleById(id));
                    string oldImage = (oldArticle.ImageLink.ToString()).Substring(57);
                    if (oldImage != null)
                    {
                        var currentImagePath = Path.Combine("wwwroot/images/articles" + "/" + oldArticle.CategoryId, oldImage);
                        if (System.IO.File.Exists(currentImagePath))
                        {
                            System.IO.File.Delete(currentImagePath);
                        }
                        if (article != null)
                            _storageService.DeleteBlobImage(oldImage, Convert.ToInt32(oldArticle.CategoryId));
                    }

                    //Below code is written to add an updated image to folder and blob
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
            string image = article.ImageLink.ToString();
            var currentImagePath = Path.Combine("wwwroot/images/articles" + "/" + article.CategoryId, image.Substring(57));
            if (System.IO.File.Exists(currentImagePath))
            {
                System.IO.File.Delete(currentImagePath);
            }
            if (article != null)
                _storageService.DeleteBlobImage(image.Substring(57), Convert.ToInt32(article.CategoryId));
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
