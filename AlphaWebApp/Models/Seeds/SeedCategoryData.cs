﻿using AlphaWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AlphaWebApp.Models.Seeds
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
                         name = "Home",
                         icon = "fa-solid fa-map-pin"
                     },

                    new Category
                    {
                        name = "Local",
                        icon = "fa-solid fa-map-pin"
                    },

                    new Category
                    {
                        name = "Sweden",
                        icon = "fa-sharp fa-solid fa-map"
                    },

                    new Category
                    {
                        name = "World",
                        icon = "fa-solid fa-earth-americas"
                    },               

                    new Category
                    {
                        name = "Economy",
                        icon = "fa-solid fa-chart-simple"
                    },

                    new Category
                    {
                        name = "Health",
                        icon = "fa-solid fa-heart-pulse"
                    },

                    new Category
                    {
                        name = "Technology",
                        icon = "fa-solid fa-medal"
                    },


                    new Category
                    {
                        name = "Sport",
                        icon = "fa-solid fa-medal"
                    }





                );
                context.SaveChanges();
            }
        }
    }
}
