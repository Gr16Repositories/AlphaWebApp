using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlphaWebApp.Models.ViewModels
{
    public class UserCategoriesSelectionVM
    {
        public List<SelectListItem> Categories { get; set; }

        public UserCategoriesSelectionVM()
        {
            Categories= new List<SelectListItem>();
        }
    }
}
