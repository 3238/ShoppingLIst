using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListApp.Infrastructure.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                AppDbContext context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                if (!context.ShoppingItems.Any())
                {
                    context.AddRange
                        (
                       new ShoppingItem() { Name = "Grote look", Store = Store.Colruyt },
                       new ShoppingItem() { Name = "Boter" },
                       new ShoppingItem() { Name = "Melk" },
                       new ShoppingItem() { Name = "Suiker" }
                        );
                }

                context.SaveChanges();
            }
        }
    }
}
