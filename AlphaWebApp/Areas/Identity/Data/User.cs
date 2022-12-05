using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using AlphaWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace AlphaWebApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser
{
    // ask about if I inhrit a user so do I have to include Id in this situation
    //public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string  DateOfBirth { get; set; }

    // do I have to inculde this line if I have navigation prop, look at the previous example.
    //public List<Supscription> supscriptionsList { get; set; }

    public virtual ICollection<Supscription> SupscriptionsList { get; set;}
}

