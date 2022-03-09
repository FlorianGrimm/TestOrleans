namespace TestWebApp;

public class Program {
    public static void Main(string[] args) {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) {
        return Host.CreateDefaultBuilder(args)
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
