namespace TestWebAppSwaggerGenerator.Pages;
[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel {
    public string RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    private readonly ILogger<ErrorModel> _logger;

    public ErrorModel(ILogger<ErrorModel> logger) {
        this._logger = logger;
        this.RequestId = String.Empty;
    }

    public void OnGet() {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
}
