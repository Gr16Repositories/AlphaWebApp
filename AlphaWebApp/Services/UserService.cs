using AlphaWebApp.Models;
using AlphaWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Versioning;

namespace AlphaWebApp.Services
{
    public class UserService: IUserService
    {
        IList<User> UserList=new List<User> {
        new User(){FirstName="Padmini",LastName="Dhanapal"},
        new User(){FirstName="Dani",LastName="Barker"},
        new User(){FirstName="Claire",LastName="Bautista"},
        new User(){FirstName="Alexa",LastName="John"},

        };

        private readonly ApplicationDbContext _db;
        public UserService( ApplicationDbContext db)
        {
            _db = db;
                
        }
        public List<User> GetCustoners()
        {
            List<User>  UserLists = UserList.OrderBy(s => s.Id).ToList();
            return UserLists;
        }
        //public void EditUser( User user)
        //{
        //    UserList.Update(User);
        //}
        //public void DeleteUser(int id)
        //{
        //    var deledterecord = UserList.Find(id);
        //    if(id != null)
        //    {
        //        UserList.Remove(deledterecord);
        //    }
        //}

        public void CreteUser([Bind("Id,FirstName,LastName,DataofBirth")] User user)
        {
            UserList.Add(user);
            
           
        }
        
        //public User DetailsUser(int id)
        //{
        //    if (id != null)
        //    {
        //        var userdetails = UserList.FirstOrDefault(c => c.Id == id);
        //        return userdetails;
        //    }
        //    else
        //    return null;

        //}


    }
}
