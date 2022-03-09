
using Microsoft.AspNetCore.TestHost;

namespace TestWebAppTest;

public class TestWebApplicationFactory : WebApplicationFactory<TestStartup> {
    public TestWebApplicationFactory() {
    }
    protected override IHostBuilder? CreateHostBuilder() {
        var hostBuilder = TestStartup.CreateHostBuilderForTesting(new string[0]);
        hostBuilder.UseEnvironment("Development");

        return hostBuilder;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder) {
        builder.UseSetting("TEST_CONTENTROOT_TestWebAppTest", @"C:\temp\TestWebApp\TestWebApp");
        base.ConfigureWebHost(builder);
    }

    protected override TestServer CreateServer(IWebHostBuilder builder) {
        //builder.UseContentRoot(@"C:\temp\TestWebApp\TestWebApp");
        //builder.UseSetting("TEST_CONTENTROOT_TestWebAppTest", @"C:\temp\TestWebApp\TestWebApp");
        return base.CreateServer(builder);
    }
}
