using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using AlphaWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace AlphaWebApp.Models;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser
{
    // ask about if I inhrit a user so do I have to include Id in this situation
    //public int Id { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    [Display(Name = "Date Of Birth")]

    public string DateOfBirth { get; set; }
    //[Required]
    //[StringLength(50, MinimumLength = 6)]
    //[Display(Name = "Email Address")]
    //[DataType(DataType.EmailAddress)]
    //public string EmailAddress { get; set; }
    
    //public string PassWord { get; set; }
    
    //public string ConfromPassWord { get; set; }



    public virtual ICollection<Subscription> SupscriptionsList { get; set; }
}

