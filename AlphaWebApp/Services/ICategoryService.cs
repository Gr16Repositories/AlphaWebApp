using AlphaWebApp.Models;

namespace AlphaWebApp.Services
{
    public interface ICategoryService
    {
        List<Category> GetAllCategory();
        void AddCategory(Category newCategory);

        void UpdateCategory(int? id, Category newCategory);

        Category GetCategoryById(int? id);

        void DeleteCategory(int? id);
    }
}
