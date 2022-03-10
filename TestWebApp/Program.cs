namespace TestWebApp;

public class Program {
    public static void Main(string[] args) {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostBuilder, configurationBuilder) => {
                if (System.IO.File.Exists(@"C:\secure\TestOrleans.appsettings.json")) {
                    configurationBuilder.AddJsonFile(@"C:\secure\TestOrleans.appsettings.json", true, true);
                }
            })
            .UseOrleans(builder => {
                builder.UseLocalhostClustering();
                builder.AddMemoryGrainStorageAsDefault();
                builder.AddMemoryGrainStorage("PubSubStore");
            })
            .ConfigureWebHostDefaults(webBuilder => {
                
                //webBuilder.ConfigureKestrel((kestrelServerOptions) => {
                //    kestrelServerOptions.ListenLocalhost(44344);                    
                //});
                webBuilder.UseStartup<Startup>();
            });
    }
}
/*
 https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel/endpoints?view=aspnetcore-6.0
https://devblogs.microsoft.com/dotnet/configuring-https-in-asp-net-core-across-different-platforms/
https://github.com/domaindrivendev/Swashbuckle.AspNetCore
https://andrewlock.net/exploring-dotnet-6-part-5-supporting-ef-core-tools-with-webapplicationbuilder/
 */
