using AlphaWebApp.Data;
using AlphaWebApp.Models.ViewModels;
using AlphaWebApp.Models;
using AutoMapper;

namespace AlphaWebApp.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Category> GetAllCategory()
        {
            return _db.Categories.ToList();
        }

        public void AddCategory(Category newCategory)
        {
            _db.Add(newCategory);
            _db.SaveChanges();
        }

        public void UpdateCategory(int? id, Category newCategory)
        {
            if (newCategory != null)
            {
                _db.Categories.Update(newCategory);
                _db.SaveChanges();
            }
        }

        public Category GetCategoryById(int? id)
        {
            Category specificCategoryById = _db.Categories.FirstOrDefault(x => x.Id == id);
            return specificCategoryById;
        }

        public void DeleteCategory(int? id)
        {
            Category categoryDetails = _db.Categories.Find(id);
            if (categoryDetails != null)
            {
                _db.Categories.Remove(categoryDetails);
                _db.SaveChanges();
            }
        }

    }
}
