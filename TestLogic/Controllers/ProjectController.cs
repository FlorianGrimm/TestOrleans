namespace TestLogic.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase {
    private readonly IClusterClient _Client;

    public ProjectController(IClusterClient client) {
        this._Client = client;
    }

    // GET: api/Project
    [HttpGet]
    public IEnumerable<ProjectRecord> Get() {
        return new ProjectRecord[] { };
    }

    // GET api/Project/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectRecord>> GetAsync(Guid id) {
        var result = await this._Client.GetGrain<IProjectGrain>(id).GetProject();
        return result;

    }

    // POST api/Project
    [HttpPost]
    public async Task PostAsync([FromBody] ProjectRecord value) {
        if (value.Id == Guid.Empty) {
            value = value with {
                Id = Guid.NewGuid()
            };
        }
        await this._Client.GetGrain<IProjectGrain>(value.Id).UpsertProject(value);
    }

    // PUT api/Project/5
    [HttpPut("{id}")]
    public async Task PutAsync(Guid id, [FromBody] ProjectRecord value) {
        value = value with { Id = id };
        await this._Client.GetGrain<IProjectGrain>(id).UpsertProject(value);
    }

    // DELETE api/Project/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id) {
        if (id == Guid.Empty) {
            return NotFound();
        } else {
            if (await this._Client.GetGrain<IProjectOverviewGrain>(Guid.Empty).DoesProjectExists(id)) {
                await this._Client.GetGrain<IProjectGrain>(id).DeleteProject();
                return Ok();
            } else {
                return NotFound();
            }
        }
    }
}