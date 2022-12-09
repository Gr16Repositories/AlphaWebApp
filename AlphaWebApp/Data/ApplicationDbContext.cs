using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AlphaWebApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;

namespace AlphaWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    //public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        
    }
}