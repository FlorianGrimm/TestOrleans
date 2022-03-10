using Orleans;

namespace TestGrainInterfaces;

[Serializable]
public record class ProjectRecord(
        Guid Id,
        string Name,
        string Comment
    ) {
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset ModifiedAt { get; init; }
}

[Serializable]
public record class ProjectCreate(
        Guid? Id,
        string Name,
        string Comment,
        DateTimeOffset? CreatedAt
    ) {

    public DateTimeOffset Created { get; init; } = DateTimeOffset.Now;
}

public interface IProjectOverviewGrain : IGrainWithGuidKey {
    Task<List<ProjectRecord>> GetProjects();
    Task InternalUpsertProject(ProjectRecord project);
    Task InternalDeleteProject(ProjectRecord project);
    Task<bool> DoesProjectExists(Guid id);
}

public interface IProjectGrain : IGrainWithGuidKey {
    Task<bool> Create(ProjectCreate prj);
    Task<ProjectRecord> GetProject();
    Task<ProjectRecord> UpsertProject(ProjectRecord project);
    Task DeleteProject();

    //Task<List<ProjectRecord>> GetProjects();
    //Task<ProjectRecord> InsertProject(ProjectRecord project);
    //Task<ProjectRecord> UpdateProject(ProjectRecord project);
    //Task<ProjectRec[]> ReadHistory(int numberOfMessages);
    //Task<string[]> GetMembers();
}
