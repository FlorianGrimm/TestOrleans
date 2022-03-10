namespace TestWebAppSwaggerGenerator;

public class Startup {
    public static StartupImplementation? TesterInjection;

    private readonly StartupImplementation _Implementation;

    public Startup(
        IConfiguration configuration,
        Microsoft.AspNetCore.Hosting.IWebHostEnvironment webHostEnvironment
        ) {
        Configuration = configuration;
        this.WebHostEnvironment = webHostEnvironment;
        this._Implementation = TesterInjection ?? new StartupSwaggerGeneratorImplementation();
    }

    public IConfiguration Configuration { get; }

    public IWebHostEnvironment WebHostEnvironment { get; }


    public void ConfigureServices(IServiceCollection services) {
        this._Implementation.ConfigureServices(services, this.Configuration, this.WebHostEnvironment);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        this._Implementation.Configure(app, env);
    }
}
public class StartupSwaggerGeneratorImplementation : StartupImplementation {
    public override bool ConfigureServicesForAuthentication(IServiceCollection services) {
        services.UseSillyAuthentication(options => { });
        return false;
    }
}