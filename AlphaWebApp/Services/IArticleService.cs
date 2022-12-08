using AlphaWebApp.Models;
using AlphaWebApp.Models.ViewModels;

namespace AlphaWebApp.Services
{
    public interface IArticleService
    {

        //Add Article
        public void AddArticle(Article article);

        //Update Article
        public void UpdateArticle(int id, Article article);

        //Get All List of Articles Details
        public List<Article> GetAllArticles();

        //Get specific Article by Id
        public Article GetArticleById(int id);

        //Delete Article 
        public void DeleteArticle(int id);

        // Saving article and blob uri in Azure
        void SaveArticle(AddArticleVM addArticleVM, Uri blobUri);

    }
}
