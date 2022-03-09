using Orleans;

namespace TestGrainInterfaces;

[Serializable]
public record class ProjectRecord(
        string Name,
        string Comment
    ) {
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset ModifiedAt { get; init; }
}

[Serializable]
public record class ProjectCreate(
        string Name,
        string Comment,
        DateTimeOffset? CreatedAt
    ) {

    public DateTimeOffset Created { get; init; } = DateTimeOffset.Now;
}

public interface IProjectGrain : IGrainWithGuidKey {
    Task<bool> Create(ProjectCreate prj);
    Task<List<ProjectRecord>> GetProjects();
    Task<ProjectRecord> GetProject(Guid id);
    Task<ProjectRecord> InsertProject(ProjectRecord project);
    Task<ProjectRecord> UpdateProject(ProjectRecord project);
    Task<ProjectRecord> DeleteProject(ProjectRecord project);
    //Task<ProjectRec[]> ReadHistory(int numberOfMessages);
    //Task<string[]> GetMembers();
}
