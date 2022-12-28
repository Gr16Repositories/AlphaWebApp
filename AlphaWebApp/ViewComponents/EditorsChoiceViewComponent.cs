using AlphaWebApp.Data;
using AlphaWebApp.Models;
using AlphaWebApp.Services;
using Microsoft.AspNetCore.Mvc;
namespace AlphaWebApp.ViewComponents
{
    public class EditorsChoiceViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _db;
        private readonly IArticleService _articleService;
        public EditorsChoiceViewComponent(ApplicationDbContext db, IArticleService articleService)
        {

            _db = db;
            _articleService = articleService;
        }
        public IViewComponentResult Invoke( int id)
        {
            var articleList = _db.Articles.Where(a => a.EditorsChoice == true).Take(5).ToList();
           
              return View(articleList);
                    


        }
    }
}
