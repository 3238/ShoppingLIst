using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Net.Http.Headers;
using ShoppingListApp.Infrastructure.Models;
using Xunit;

namespace ShoppingList.ModelTests
{
    public class ShoppingItemShould
    {
        private readonly AppDbContext context;
        private Random random = new Random();

        public ShoppingItemShould()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            this.context = new AppDbContext(builder.Options);
        }

        [Fact]
        public void ReadFromDatabase()
        {
            Assert.True(context.ShoppingItems.Count() > 0);
        }

        [Fact]
        public void AddNewItems()
        {
            string newItemName = "Model Test Item " + random.Next(1111, 9999);
            context.ShoppingItems.Add( new ShoppingItem() { Name = newItemName, Store = Store.Lidl } );
            context.SaveChanges();
            Assert.True(context.ShoppingItems.FirstOrDefault(x => x.Name == newItemName) != null);
        }

        [Fact]
        public void SaveAllFields()
        {
            string newItemName = "Model Test Item " + random.Next(1111, 9999);
            Store store = Store.Carrefour;
            bool urgent = true;
            context.ShoppingItems.Add(new ShoppingItem() { Name = newItemName, Store = store, Urgent = urgent });
            context.SaveChanges();
            Assert.True(context.ShoppingItems.FirstOrDefault(x => x.Name == newItemName && x.Store == store && x.Urgent == urgent && x.ID > 0) != null);
        }
    }
}
