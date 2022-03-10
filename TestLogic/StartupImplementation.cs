
namespace TestLogic;
public class StartupImplementation {
    public virtual void ConfigureServices(
        IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment webHostEnvironment) {
        if (this.ConfigureServicesForAuthentication(services)) {
            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(configuration.GetSection("AzureAd"));
        }

        services.AddAuthorization(options => {
            // By default, all incoming requests will be authorized according to the default policy
            options.FallbackPolicy = options.DefaultPolicy;
        });

        services.AddRazorPages()
            .ConfigureApplicationPartManager((applicationPartManager) => {
                applicationPartManager.ApplicationParts.Add(new AssemblyPart(typeof(ValuesController).Assembly));
            })
            .AddMvcOptions(options => {
            })
            .AddMicrosoftIdentityUI();

        services.AddMvcCore().AddApiExplorer();

        services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });
    }
    public virtual bool ConfigureServicesForAuthentication(IServiceCollection services) => true;

    public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

        if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        } else {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
            endpoints.MapSwagger();
        });

        app.UseSwaggerUI(c => {
            c.SwaggerEndpoint("v1/swagger.json", "My API V1");
        });
    }
}