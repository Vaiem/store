using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Store.Models;

namespace Store.Models
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder apps)
        {
            ApplicationDbContext app = apps.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            app.Database.Migrate();
            if (!app.Products.Any())
            {
                app.Products.AddRange(
                new Product
                { Name = "Jacet",Categoria ="Football",Price = 12.3m, Description="FootbalTovar" },
                new Product
                { Name = "PS4", Categoria = "Game", Price = 12.5m, Description = "GameTovar" }
                );
            }
            app.SaveChanges();
        }


    }
}
