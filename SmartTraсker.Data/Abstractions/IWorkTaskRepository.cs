using SmartTraсker.Data.Models;

namespace SmartTraсker.Data.Abstractions;

public interface IWorkTaskRepository
{
    public Task<List<WorkTask>> Get();
    public Task<List<WorkTask>> GetWithAll();
    public Task<WorkTask?> GetById(Guid id);
    public Task<List<WorkTask>> GetByStatus(WorkTaskStatus status);
    public Task<List<WorkTask>> GetByPriority(WorkTaskPriority priority);
    public Task<WorkTask?> GetByIdWithAll(Guid id);
    public Task Add(WorkTask newTask);
    public Task Update(WorkTask newWorkTask);
    public Task Delete(Guid id);
}