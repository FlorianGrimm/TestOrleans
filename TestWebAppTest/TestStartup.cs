
namespace TestWebAppTest;

public class TestStartup : Startup {
    public static IHostBuilder CreateHostBuilderForTesting(string[] args) {
        string p = typeof(TestStartup).Assembly.Location;
        return Host.CreateDefaultBuilder(args)
            .UseOrleans(builder => {
                builder.UseLocalhostClustering();
                builder.AddMemoryGrainStorageAsDefault();
                builder.AddMemoryGrainStorage("PubSubStore");
            })
            //.UseContentRoot(@"C:\temp\TestWebApp\TestWebApp")
            .ConfigureAppConfiguration(options => { 
                //options.Properties
            })
            .ConfigureHostOptions(options => { 
                //options.Properties
            })
            //.ConfigureWebHost(webBuilder => {
            //    //webBuilder.UseContentRoot(@"C:\temp\TestWebApp\TestWebApp");
            //    //webBuilder.UseWebRoot(@"C:\temp\TestWebApp\TestWebApp\wwwroot");
            //    webBuilder.UseStartup<TestStartup>();
            //})
            .ConfigureWebHostDefaults(webBuilder => {
                //webBuilder.UseContentRoot(@"C:\temp\TestWebApp\TestWebApp");
                webBuilder.UseWebRoot(@"C:\temp\TestWebApp\TestWebApp\wwwroot");
                webBuilder.UseStartup<TestStartup>();
            });
    }

    public TestStartup(
        IConfiguration configuration,
        Microsoft.AspNetCore.Hosting.IWebHostEnvironment webHostEnvironment
        ) : base(configuration, webHostEnvironment) {
        //webHostEnvironment.ContentRootPath = @"C:\temp\TestWebApp\TestWebApp";
        //webHostEnvironment.WebRootPath = @"C:\temp\TestWebApp\TestWebApp\wwwroot";

    }

    public override void ConfigureServices(IServiceCollection services) {
        services.AddRazorPages().ConfigureApplicationPartManager(apm => {
            apm.ApplicationParts.Add(new Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart(typeof(Program).Assembly));
        });
        base.ConfigureServices(services);
    }

    public override bool ConfigureServicesForAuthentication(IServiceCollection services) {
        services.UseMockAuthentication(options => {
        });
        return false;
    }
}
/*
 https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel/endpoints?view=aspnetcore-6.0
 */