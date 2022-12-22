﻿using System;
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
        public virtual ICollection<Subscription> SubscriptionList { get; set; }

        public virtual ICollection<Like> Like { get; set; }

    }
}
