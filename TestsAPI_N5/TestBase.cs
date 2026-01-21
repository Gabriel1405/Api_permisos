using Microsoft.AspNetCore.Mvc.Testing;

namespace TestsAPI_N5
{
    public class TestBase : IClassFixture<WebApplicationFactory<Program>>
    {
        protected readonly HttpClient _client;

        public TestBase(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }
    }

}
