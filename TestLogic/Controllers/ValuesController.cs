namespace TestLogic.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase {
    [HttpGet]
    public string Hello() {
        return "World";
    }
}
