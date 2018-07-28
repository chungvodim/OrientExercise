using ApplicationCore.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApp;
using Xunit;

namespace FunctionalTests.WebApi.Controllers
{
    public class ProductControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        public ProductControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnsFirst10CatalogItems()
        {
            var response = await Client.GetAsync("/Product/GetProductsByPackageID?PackageID=1");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(stringResponse);

            Assert.Equal(2, model.Count());
        }
    }
}
