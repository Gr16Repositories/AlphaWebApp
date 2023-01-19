using AlphaWebApp.Models;
using AlphaWebApp.Models.ViewModels;

namespace AlphaWebApp.Services
{
    public interface IArticleService
    {

        //Add Article and save the article images in blob in Azure
        public void AddArticle(AddArticleVM article, Uri blobUri);

        public void SaveViewsToArticle(int id, int viewCount);

        public void SaveLikes(Like like);

        public void RemoveLikes(Like like);

        //Update Article
        public void UpdateArticle(int id, EditArticleVM article, Uri blobUri);

        public void UpdateArticleWithOutImage(int id, EditArticleVM article);

        //Get All List of Articles Details
        public List<Article> GetAllArticles();

        //Get specific Article by Id
        public Article GetArticleById(int? id);

        //Delete Article 
        public void DeleteArticle(int id);

        //Get Category Details
        public List<Category> GetCategories();

        public Category GetCategoryById(int id);
        List<Article> GetArticlesByCategoryName(string name);
        List<Article> GetArticlesByCategoryId(int id);
        public Article GetSpecificArticleByCategoryId(int id);

        public List<Article> GetAllArticlesForSearch();
    }
}
