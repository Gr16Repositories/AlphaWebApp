using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AlphaWebApp.Models
{
    public class User  : IdentityUser
    {
        [PersonalData]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [PersonalData]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [PersonalData]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [PersonalData]
        [DataType(DataType.Date)]
        public virtual ICollection<Subscription> SupscriptionsList { get; set; }

        public User()
        {
            List<Subscription> SupscriptionsList = new List<Subscription>();
        }
    }
}
