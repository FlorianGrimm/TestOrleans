
namespace TestWebAppTest;
public class UnitTest1
    : IClassFixture<TestWebApplicationFactory> {
    private readonly TestWebApplicationFactory _WebApplicationFactory;

    public UnitTest1(TestWebApplicationFactory factory) {
        this._WebApplicationFactory = factory;
    }

    [Theory]
    [InlineData("/")]
    [InlineData("/Index")]
    [InlineData("/About")]
    [InlineData("/Privacy")]
    [InlineData("/Contact")]
    [InlineData("/swagger")]
    public async Task Test1Async(string url) {
        var client = this._WebApplicationFactory.CreateClient();
        
        var response = await client.GetAsync(url);

        Assert.Equal(System.Net.HttpStatusCode.Found, response.StatusCode);
        //response.EnsureSuccessStatusCode(); // Status Code 200-299
        //Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType?.ToString());
    }
}
