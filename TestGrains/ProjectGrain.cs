
namespace TestGrains;

public class ProjectGrain : Grain, IProjectGrain {
    private readonly IPersistentState<ProjectRecord> _ProjectState;

    public ProjectGrain(
        [PersistentState("Project")] IPersistentState<ProjectRecord> project
        ) {
        this._ProjectState = project ?? throw new ArgumentNullException(nameof(project));

    }

    public async Task<bool> Create(ProjectCreate prj) {
        this._ProjectState.State = new ProjectRecord(prj.Name, prj.Comment) { 
            CreatedAt = DateTimeOffset.Now,
            ModifiedAt = DateTimeOffset.Now
        };
        await this._ProjectState.WriteStateAsync();
        return true;
    }

    public ProjectRecord GetProject() {
        return this._ProjectState.State;
    }


    //private IAsyncStream<ChatMsg> _stream = null!;

    //public override Task OnActivateAsync() {
    //    //var streamProvider = GetStreamProvider("chat");

    //    //_stream = streamProvider.GetStream<ChatMsg>(
    //    //    Guid.NewGuid(), "default");

    //    return base.OnActivateAsync();
    //}
}
