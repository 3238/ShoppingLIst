using Microsoft.AspNetCore.Hosting;
using System;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ShoppingList.IntegrationTests
{
    public class ShoppingListShould
    {
        [Fact]
        public async Task RenderForm()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new WebHostBuilder()
                .UseContentRoot(@"H:\Software\Tests\ShoppingList\ShoppingListApp")
                .UseEnvironment("Development")
                .UseConfiguration(config)
                .UseStartup<ShoppingListApp.Startup>();
            var testServer = new TestServer(builder);
            var client = testServer.CreateClient();
            var response = await client.GetAsync("");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Nieuw item toevoegen", responseString);
        }
    }
}
