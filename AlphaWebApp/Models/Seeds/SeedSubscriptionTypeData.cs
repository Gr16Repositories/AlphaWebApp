using AlphaWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AlphaWebApp.Models.Seeds
{
    public class SeedSubscriptionTypeData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.SubscriptionTypes.Any())
                {
                    return;
                }
                context.SubscriptionTypes.AddRange(
                    new SubscriptionType
                    {
                        TypeName = "Free",
                        Description = "No fee. No access to extra features."
                    },

                    new SubscriptionType
                    {
                        TypeName = "Basic",
                        Description = "Small fee. Small access to extra features."
                    },

                    new SubscriptionType
                    {
                        TypeName = "Standard",
                        Description = "Medium fee. Medium access to extra features."
                    },

                    new SubscriptionType
                    {
                        TypeName = "Premium",
                        Description = "Large fee. Full access to all features."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
