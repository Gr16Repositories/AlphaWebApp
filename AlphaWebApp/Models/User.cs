using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using AlphaWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace AlphaWebApp.Models
{

// Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
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
        public virtual ICollection<Subscription> SubscriptionsList { get; set; }

        public User()
        {
            List<Subscription> SupscriptionsList = new List<Subscription>();
        }
    }
}
