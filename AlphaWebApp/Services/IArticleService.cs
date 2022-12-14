using AlphaWebApp.Models;
using AlphaWebApp.Models.ViewModels;

namespace AlphaWebApp.Services
{
    public interface IArticleService
    {

        //Add Article and save the article images in blob in Azure
        public void AddArticle(AddArticleVM article, Uri blobUri);

        //Update Article
        public void UpdateArticle(int? id, EditArticleVM article, Uri blobUri);

        //Get All List of Articles Details
        public List<Article> GetAllArticles();

        //Get specific Article by Id
        public Article GetArticleById(int? id);

        //Delete Article 
        public void DeleteArticle(int id);

        //Get Category Details
        public List<Category> GetCategories();

       

    }
}
