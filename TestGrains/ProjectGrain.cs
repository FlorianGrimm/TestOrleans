
namespace TestGrains;

public class ProjectGrain : Grain, IProjectGrain {
    private readonly IPersistentState<ProjectRecord> _ProjectState;

    public ProjectGrain(
        [PersistentState("Project")] IPersistentState<ProjectRecord> project
        ) {
        this._ProjectState = project ?? throw new ArgumentNullException(nameof(project));

    }

    public async Task<bool> Create(ProjectCreate prj) {
        this._ProjectState.State = new ProjectRecord(Guid.NewGuid(), prj.Name, prj.Comment) {
            CreatedAt = DateTimeOffset.Now,
            ModifiedAt = DateTimeOffset.Now
        };
        await this._ProjectState.WriteStateAsync();
        return true;
    }


    public async Task<ProjectRecord> GetProject() {
        await Task.CompletedTask;
        return this._ProjectState.State;
    }

    public async Task<ProjectRecord> UpsertProject(ProjectRecord project) {
        this._ProjectState.State = project;
        await this._ProjectState.WriteStateAsync();
        await this.GrainFactory.GetGrain<IProjectOverviewGrain>(Guid.Empty).InternalUpsertProject(project);
        return this._ProjectState.State!;
    }

    public async Task DeleteProject() {
        if (this._ProjectState.RecordExists) {
#warning TODO            this._ProjectState.Etag=null;
            var project=this._ProjectState.State;
            await this._ProjectState.ClearStateAsync();
            await this.GrainFactory.GetGrain<IProjectOverviewGrain>(Guid.Empty).InternalDeleteProject(project);
        }
    }
}

public class ProjectOverviewGrain : Grain, IProjectOverviewGrain {
    private Dictionary<Guid, ProjectRecord>? _Projects;

    public ProjectOverviewGrain() {
    }

    public async Task<List<ProjectRecord>> GetProjects() {
        await Task.CompletedTask;
        var projects = this._Projects;
        if (projects is null) {
            return new List<ProjectRecord>();
        } else {
            return projects.Values.ToList();
        }
    }

    public async Task<bool> DoesProjectExists(Guid id) {
        await Task.CompletedTask;
        var projects = this._Projects;
        if (projects is null) {
            return false;
        } else {
            return projects.ContainsKey(id);
        }
    }

    public async Task InternalUpsertProject(ProjectRecord project) {
        await Task.CompletedTask;
        var projects = this._Projects ??= new Dictionary<Guid, ProjectRecord>();
        projects.Add(project.Id, project);
    }

    public async Task InternalDeleteProject(ProjectRecord project) {
        await Task.CompletedTask;
        var projects = this._Projects ??= new Dictionary<Guid, ProjectRecord>();
        projects.Remove(project.Id);
    }

}