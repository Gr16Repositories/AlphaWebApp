using AlphaWebApp.Data;
using AlphaWebApp.Models;
using AlphaWebApp.Models.ViewModels;
using AutoMapper;

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

        public void AddArticle(Article article)
        {
            Article art = new Article();
            art.Id = article.Id;
            art.DateStamp = article.DateStamp;
            art.LinkText = article.LinkText;
            art.Headline = article.Headline;
            art.ContentSummary = article.ContentSummary;
            art.Content = article.Content;
            art.Views = article.Views;
            art.Likes = article.Likes;
            art.ImageLink = article.ImageLink;
            art.Category = article.Category;
            art.CoverImage = article.CoverImage;
            art.Category = article.Category;

            if (art != null)
            {
                _db.Articles.Add(art);
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
            return listOfAllArtiles;
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
        //adding this from Robert lecture
        public void SaveArticle(AddArticleVM newArticle, Uri blobUri)
        {
            // using add auto mapp to move the properties to dbArticle
            Article dbArticle = _mapper.Map<Article>(newArticle);
            dbArticle.Category = _db.Categories.Find(Convert.ToInt32(newArticle.CategoryId));
            dbArticle.ImageLink = blobUri;
            dbArticle.DateStamp = DateTime.Now;
            

            _db.Articles.Add(dbArticle);
            _db.SaveChanges();
        }
    }
}
