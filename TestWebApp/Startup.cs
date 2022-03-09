using Microsoft.OpenApi.Models;

namespace TestWebApp;

public class Startup {

    public Startup(
        IConfiguration configuration, 
        Microsoft.AspNetCore.Hosting.IWebHostEnvironment webHostEnvironment
        ) {
        Configuration = configuration;
        this.WebHostEnvironment = webHostEnvironment;
    }

    public IConfiguration Configuration { get; }

    public IWebHostEnvironment WebHostEnvironment { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public virtual void ConfigureServices(IServiceCollection services) {
        if (this.ConfigureServicesForAuthentication(services)) {
            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(Configuration.GetSection("AzureAd"));
        }

        services.AddAuthorization(options => {
            // By default, all incoming requests will be authorized according to the default policy
            options.FallbackPolicy = options.DefaultPolicy;
        });

        services.AddRazorPages()
            .AddMvcOptions(options => { })
            .AddMicrosoftIdentityUI();

        services.AddMvcCore().AddApiExplorer();

        services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });
    }

    public virtual bool ConfigureServicesForAuthentication(IServiceCollection services) => true;

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
