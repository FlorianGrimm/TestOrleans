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
