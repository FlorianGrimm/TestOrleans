
namespace TestWebAppTest;

public class TestStartup : StartupImplementation {
    public static IHostBuilder CreateHostBuilderForTesting(string[] args) {
        Startup.TesterInjection = new TestStartup();
        return Host.CreateDefaultBuilder(args)
            .UseEnvironment("Testing")
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
            .ConfigureWebHostDefaults(webBuilder => {
                webBuilder.UseStartup<Startup>();
            });
    }

    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment webHostEnvironment) {
        //services.AddRazorPages().ConfigureApplicationPartManager(apm => {
        //    apm.ApplicationParts.Add(new Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart(typeof(Program).Assembly));
        //});
        base.ConfigureServices(services, configuration, webHostEnvironment);
    }

    public override bool ConfigureServicesForAuthentication(IServiceCollection services) {
        services.UseMockAuthentication(options => {
        });
        return false;
    }

    public override void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        base.Configure(app, env);
    }
}
/*
 https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel/endpoints?view=aspnetcore-6.0
 */