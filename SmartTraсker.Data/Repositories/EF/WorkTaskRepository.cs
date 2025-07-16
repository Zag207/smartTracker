using Microsoft.EntityFrameworkCore;
using SmartTraсker.Data.Abstractions;
using SmartTraсker.Data.Models;

namespace SmartTraсker.Data.Repositories.EF;

public class WorkTasksRepository(ApplicationContext db) : IWorkTaskRepository
{
    private ApplicationContext _db = db;

    public async Task<List<WorkTask>> Get()
    {
        return await _db.WorkTasks.AsNoTracking()
            .OrderBy(t => t.CreatedAt)
            .ToListAsync();
    }

    public async Task<List<WorkTask>> GetWithAll()
    {
        return await _db.WorkTasks
            .AsNoTracking()
            .Include(t => t.Comments)
            .Include(t => t.Author)
            .Include(t => t.Executor)
            .OrderBy(t => t.CreatedAt)
            .ToListAsync();
    }

    public async Task<WorkTask?> GetById(Guid id)
    {
        return await _db.WorkTasks
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<List<WorkTask>> GetByStatus(WorkTaskStatus status)
    {
        return await _db.WorkTasks
            .AsNoTracking()
            .Where(t => t.Status == status)
            .OrderBy(t => t.CreatedAt)
            .ToListAsync();
    }

    public async Task<List<WorkTask>> GetByPriority(WorkTaskPriority priority)
    {
        return await _db.WorkTasks
            .AsNoTracking()
            .Where(t => t.Priority == priority)
            .OrderBy(t => t.CreatedAt)
            .ToListAsync();
    }
    
    public async Task<WorkTask?> GetByIdWithAll(Guid id)
    {
        return await _db.WorkTasks
            .AsNoTracking()
            .Include(t => t.Comments)
            .Include(t => t.Author)
            .Include(t => t.Executor)
            .Where(t => t.Id == id)
            .OrderBy(t => t.CreatedAt)
            .FirstOrDefaultAsync();
    }

    public async Task Add(WorkTask newTask)
    {
        await _db.WorkTasks.AddAsync(newTask);
        await _db.SaveChangesAsync();
    }

    public async Task Update(WorkTask newWorkTask)
    {
        await _db.WorkTasks
            .Where(t => t.Id == newWorkTask.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(t => t.Name, newWorkTask.Name)
                .SetProperty(t => t.Description, newWorkTask.Description)
                .SetProperty(t => t.Status, newWorkTask.Status)
                .SetProperty(t => t.Priority, newWorkTask.Priority)
                .SetProperty(t => t.CreatedAt, newWorkTask.CreatedAt)
                .SetProperty(t => t.Deadline, newWorkTask.Deadline)
                .SetProperty(t => t.AuthorId, newWorkTask.AuthorId)
                .SetProperty(t => t.ExecutorId, newWorkTask.ExecutorId)
            );
    }

    public async Task Delete(Guid id)
    {
        await _db.WorkTasks.Where(u => u.Id == id).ExecuteDeleteAsync();
    }
}
