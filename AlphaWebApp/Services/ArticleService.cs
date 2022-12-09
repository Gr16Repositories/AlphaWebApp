using AlphaWebApp.Data;
using AlphaWebApp.Models;
using AlphaWebApp.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

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

            _db.Articles.Add(dbArticle);
            _db.SaveChanges();
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
            //List<Article> listOfAllArtiles = _db.Articles.ToList();
            //return listOfAllArtiles;
            return null;
        }

        public Article GetArticleById(int id)
        {
            Article specificArticleById = _db.Articles.FirstOrDefault(x => x.Id == id);
            return specificArticleById;
        }

        public void UpdateArticle(int id, Article article)
        {
            Article articleDetails = _db.Articles.Find(id);
            if (articleDetails != null)
            {
                _db.Articles.Update(article);
                _db.SaveChanges();
            }

        }

        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }       
    }
}
