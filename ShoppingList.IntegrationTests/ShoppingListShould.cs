using Microsoft.AspNetCore.Hosting;
using System;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Collections.Generic;
using Microsoft.Net.Http.Headers;

namespace ShoppingList.IntegrationTests
{
    public class ShoppingListShould : IClassFixture<TestServerFixture>
    {
        private static Random random = new Random();
        private readonly TestServerFixture fixture;

        public ShoppingListShould(TestServerFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task RenderForm()
        {
            var response = await fixture.Client.GetAsync("");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Nieuw item toevoegen", responseString);
        }


        [Fact]
        public async Task AddNewItem()
        {
            HttpResponseMessage initialResponse = await fixture.Client.GetAsync("/ShoppingList/List");
            var antiForgeryValues = await fixture.ExtractAntiForgeryValues(initialResponse);
            
            HttpRequestMessage postReq = new HttpRequestMessage(HttpMethod.Post, "/ShoppingList/AddShoppingItem");
            postReq.Headers.Add("Cookie", new CookieHeaderValue(TestServerFixture.AntiForgeryCookieName, antiForgeryValues.cookieValue).ToString());

            string randomNr = random.Next(1111, 9999).ToString();
            string newItemTxt = "New Test Item " + randomNr;
            var formData = new Dictionary<string, string>
            {
                {TestServerFixture.AntiForgeryFieldName, antiForgeryValues.fieldValue},
                {"NewItemName", newItemTxt }
            };

            postReq.Content = new FormUrlEncodedContent(formData);
            HttpResponseMessage response = await fixture.Client.SendAsync(postReq);
            var responseString = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            Assert.Contains(newItemTxt, responseString);
        }

        [Fact]
        public async Task RejectEmptyNewItemNames()
        {
            HttpResponseMessage initialResponse = await fixture.Client.GetAsync("/ShoppingList/List");
            var antiForgeryValues = await fixture.ExtractAntiForgeryValues(initialResponse);

            HttpRequestMessage postReq = new HttpRequestMessage(HttpMethod.Post, "/ShoppingList/AddShoppingItem");
            postReq.Headers.Add("Cookie", new CookieHeaderValue(TestServerFixture.AntiForgeryCookieName, antiForgeryValues.cookieValue).ToString());
            
            string newItemTxt = "";
            var formData = new Dictionary<string, string>
            {
                {TestServerFixture.AntiForgeryFieldName, antiForgeryValues.fieldValue},
                {"NewItemName", newItemTxt }
            };

            postReq.Content = new FormUrlEncodedContent(formData);
            HttpResponseMessage response = await fixture.Client.SendAsync(postReq);
            var responseString = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            Assert.Contains("Geef een naam voor het nieuwe item op aub", responseString);
        }
    }
}
