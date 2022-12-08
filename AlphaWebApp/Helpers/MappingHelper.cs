using AlphaWebApp.Models;
using AlphaWebApp.Models.ViewModels;
using AutoMapper;

namespace AlphaWebApp.Helpers
{
    public class MappingHelper : Profile
    {
        public MappingHelper() 
        {
            // the order important here
            CreateMap<AddArticleVM, Article>();
        }
    }
}
