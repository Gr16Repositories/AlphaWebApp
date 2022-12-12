using AlphaWebApp.Models;
using AlphaWebApp.Models.ViewModels;
using AutoMapper;

namespace AlphaWebApp.Helpers
{
    public class MappingHelper : Profile
    {
        public MappingHelper() 
        {
            //automap the ArticleVM and article
            // the order important here
            CreateMap<AddArticleVM, Article>();
            //automap the EditArticleVM and article
            CreateMap<EditArticleVM, Article>();
        }
    }
}
