using AlphaWebApp.Areas.Identity.Data;

namespace AlphaWebApp.Services
{
    public interface IUserService
    {
        List<User> GetCustoners();
    }
}
