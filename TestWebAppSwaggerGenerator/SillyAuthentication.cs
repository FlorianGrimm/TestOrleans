
namespace TestWebAppSwaggerGenerator;

public static class SillyAuthentication {
    public static void UseSillyAuthentication(this IServiceCollection services, Action<SillyAuthenticationSchemeOptions>? configureOptions) {
        services.AddAuthentication("Silly")
            .AddScheme<SillyAuthenticationSchemeOptions, TestAuthHandler>("Silly", configureOptions);
    }
}

public class SillyAuthenticationSchemeOptions : AuthenticationSchemeOptions {
    public Factory<HttpContext, ClaimsPrincipal>? Factory { get; set; }
}

public class TestAuthHandler : AuthenticationHandler<SillyAuthenticationSchemeOptions> {
    public TestAuthHandler(
        IOptionsMonitor<SillyAuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock)
        : base(options, logger, encoder, clock) {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync() {
        ClaimsPrincipal principal;
        var options = this.OptionsMonitor.Get(this.Scheme.Name) ?? this.OptionsMonitor.Get(String.Empty);
        if (options?.Factory is not null) {
            principal = options.Factory(this.Context);
        } else {
            var claims = new[] { new Claim(ClaimTypes.Name, "SwaggerGeneration") };
            var identity = new ClaimsIdentity(claims, this.Scheme.Name);
            principal = new ClaimsPrincipal(identity);
        }
        if (principal is not null) {
            var ticket = new AuthenticationTicket(principal, this.Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        } else {
            return Task.FromResult(AuthenticateResult.NoResult());
        }
    }
}

