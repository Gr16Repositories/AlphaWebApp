using AlphaWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.Runtime.Intrinsics.X86;

namespace AlphaWebApp.Models
{
    public class Supscription
    {
        public int Id { get; set; }
        public decimal Pirce { get; set; }
        public DateTime Created { get; set; }
        public User  User{ get; set; }
        public bool PaymentComplete { get; set; }
        public SupscriptionType SupscriptionTypeId { get; set; }

        // look at this in previous example
        public List<User> UserList { get; set; }

        public virtual SupscriptionType SupscriptionType { get; set; }
        public  virtual ICollection<User> UsersList { get; set; }
    }
}
