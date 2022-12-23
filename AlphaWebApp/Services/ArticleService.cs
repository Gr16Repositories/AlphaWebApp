using AlphaWebApp.Data;
using AlphaWebApp.Models;
using AlphaWebApp.Models.ViewModels;
using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Policy;

namespace AlphaWebApp.Services
{
    public class ArticleService : IArticleService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ArticleService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void AddArticle(AddArticleVM newArticle, Uri blobUri)
        {
            // using add auto mapp to move the properties to dbArticle
            Article dbArticle = _mapper.Map<Article>(newArticle);
            dbArticle.Category = _db.Categories.Find(Convert.ToInt32(newArticle.CategoryId));
            dbArticle.ImageLink = blobUri;
            dbArticle.DateStamp = DateTime.Now;
            if (dbArticle != null)
            {
                _db.Articles.Add(dbArticle);
                _db.SaveChanges();
            }
        }

        public void SaveViewsToArticle(int id, int viewCount)
        {
            var articleDetails = this.GetArticleById(id);
            articleDetails.Views = viewCount;
            if (articleDetails != null)
            {
                _db.Articles.Update(articleDetails);
                _db.SaveChanges();
            }
        }

        public void SaveLikes(Like like)
        {
            if (like != null)
            {
                _db.Likes.Add(like);
                _db.SaveChanges();
            }
        }

        public void RemoveLikes(Like like)
        {
            if (like != null)
            {
                _db.Likes.Remove(like);
                _db.SaveChanges();
            }
        }

        public void DeleteArticle(int id)
        {
            Article articleDetails = _db.Articles.Find(id);
            if (articleDetails != null)
            {
                _db.Articles.Remove(articleDetails);
                _db.SaveChanges();
            }
        }

        public List<Article> GetAllArticles()
        {
            List<Article> listOfAllArtiles = _db.Articles.ToList();
            if (listOfAllArtiles != null)
                return listOfAllArtiles;
            else
                return new List<Article>();

        }

        public Article GetArticleById(int? id)
        {
            Article specificArticleById = _db.Articles.FirstOrDefault(x => x.Id == id);
            return specificArticleById;
        }

        public void UpdateArticle(int id, EditArticleVM article, Uri blobUri)
        {
            Article articleDetails = _db.Articles.Find(id);
            articleDetails.Category = _db.Categories.Find(Convert.ToInt32(article.CategoryId));
            articleDetails.ImageLink = blobUri;
            articleDetails.HeadLine = article.HeadLine;
            articleDetails.LinkText = article.LinkText;
            articleDetails.DateStamp = DateTime.Now;
            articleDetails.CategoryId = Convert.ToInt32(article.CategoryId);
            articleDetails.ContentSummary = article.ContentSummary;
            articleDetails.Content = article.Content;
            articleDetails.Views = article.Views;
            articleDetails.Likes = article.Likes;
            if (articleDetails != null)
            {
                _db.Articles.Update(articleDetails);
                _db.SaveChanges();
            }
        }
        public void UpdateArticleWithOutImage(int id, EditArticleVM article)
        {
            Article articleDetails = _db.Articles.Find(id);
            articleDetails.Category = _db.Categories.Find(Convert.ToInt32(article.CategoryId));
            articleDetails.ImageLink = articleDetails.ImageLink;
            articleDetails.HeadLine = article.HeadLine;
            articleDetails.LinkText = article.LinkText;
            articleDetails.DateStamp = DateTime.Now;
            articleDetails.CategoryId = Convert.ToInt32(article.CategoryId);
            articleDetails.ContentSummary = article.ContentSummary;
            articleDetails.Content = article.Content;
            articleDetails.Views = article.Views;
            articleDetails.Likes = article.Likes;
            if (articleDetails != null)
            {
                _db.Articles.Update(articleDetails);
                _db.SaveChanges();
            }
        }

        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _db.Categories.Find(id);
        }

        public List<Article> GetArticlesByCategoryName(string name)
        {
            return _db.Articles.Where(a => a.Category.name == name).ToList();
        }

        public List<Article> GetArticlesById(int id)
        {
            return _db.Articles.Where(a => a.CategoryId == id).ToList();
        }
    }
}
