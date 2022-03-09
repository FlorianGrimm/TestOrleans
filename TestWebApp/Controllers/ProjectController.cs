namespace TestWebApp.Controllers;
    
[Route("api/[controller]")]
[ApiController]
public class ProjectController  : ControllerBase {
    // GET: api/Project
    [HttpGet]
    public IEnumerable<string> Get() {
        return new string[] { "value1", "value2" };
    }

    // GET api/Project/5
    [HttpGet("{id}")]
    public string Get(int id) {
        return "value";
    }

    // POST api/Project
    [HttpPost]
    public void Post([FromBody] string value) {
    }

    // PUT api/Project/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value) {
    }

    // DELETE api/Project/5
    [HttpDelete("{id}")]
    public void Delete(int id) {
    }
}