using AlphaWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AlphaWebApp.Models
{
    public class SeedCategoryData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Categories.Any())
                {
                    return;
                }
                context.Categories.AddRange(
                    new Category
                    {
                        name = "Local"
                    },

                    new Category
                    {
                        name = "Sweden"
                    },

                    new Category
                    {
                        name = "World"
                    },

                    new Category
                    {
                        name = "Weather"
                    },

                    new Category
                    {
                        name = "Economy"
                    },

                    new Category
                    {
                        name = "Health"
                    },

                    new Category
                    {
                        name = "Sport"
                    },

                    new Category
                    {
                        name = "FIFA World Cup 2022"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
