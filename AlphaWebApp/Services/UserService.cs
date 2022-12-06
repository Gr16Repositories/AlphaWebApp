using AlphaWebApp.Areas.Identity.Data;
using AlphaWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Versioning;

namespace AlphaWebApp.Services
{
    public class UserService: IUserService
    {
        IList<User> UserList=new List<User> {
        new User(){Id=1,FirstName="Padmini",LastName="Dhanapal",DateOfBirth="2000/08/27", SupscriptionsListName="Basic"},
        new User(){Id=2,FirstName="Alex",LastName="Abadi", DateOfBirth="2001/01/31", SupscriptionsListName="Premium"},
        new User(){Id=3,FirstName="Dani",LastName="Barker", DateOfBirth="1990/10/15", SupscriptionsListName="Bronze"},
        new User(){Id=4,FirstName="Claire",LastName="Bautista", DateOfBirth="1994/11/06", SupscriptionsListName="Gold"},
        new User(){Id=5,FirstName="Alexa",LastName="John", DateOfBirth="1990/07/10", SupscriptionsListName="Platinum"},

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

        public void CreteUser([Bind("Id,FirstName,LastName,DataofBirth,SupscriptionsListName")] User user)
        {
            UserList.Add(user);
            
           
        }
        
        public User DetailsUser(int id)
        {
            if (id != null)
            {
                var userdetails = UserList.FirstOrDefault(c => c.Id == id);
                return userdetails;
            }
            else
            return null;

        }


    }
}
