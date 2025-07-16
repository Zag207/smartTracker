using Microsoft.EntityFrameworkCore;
using SmartTraсker.Data.Abstractions;
using SmartTraсker.Data.Models;

namespace SmartTraсker.Data.Repositories.EF;

public class CommentsRepository(ApplicationContext db) : ICommentsRepository
{
    private ApplicationContext _db = db;

    public async Task<List<Comment>> Get()
    {
        return await _db.Comments
            .AsNoTracking()
            .Include(c => c.Task)
            .Include(c => c.Author)
            .ToListAsync();
    }

    public async Task<Comment?> GetById(Guid id)
    {
        return await _db.Comments
            .AsNoTracking()
            .Include(c => c.Task)
            .Include(c => c.Author)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Comment>> GetByTaskId(Guid taskId)
    {
        return await _db.Comments
            .AsNoTracking()
            .Include(c => c.Task)
            .Include(c => c.Author)
            .Where(c => c.TaskId == taskId)
            .ToListAsync();
    }

    public async Task<List<Comment>> GetByAuthorId(Guid authorId)
    {
        return await _db.Comments
            .AsNoTracking()
            .Include(c => c.Task)
            .Include(c => c.Author)
            .Where(c => c.AuthorId == authorId)
            .ToListAsync();
    }

    public async Task<List<Comment>> GetWithAuthor()
    {
        return await _db.Comments
            .AsNoTracking()
            .Include(c => c.Author)
            .ToListAsync();
    }

    public async Task<Comment?> GetByIdWithAuthor(Guid id)
    {
        return await _db.Comments
            .AsNoTracking()
            .Include(c => c.Author)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
    }
    
    public async Task<List<Comment>> GetWithTask()
    {
        return await _db.Comments
            .AsNoTracking()
            .Include(c => c.Task)
            .ToListAsync();
    }

    public async Task<Comment?> GetByIdWithTask(Guid id)
    {
        return await _db.Comments
            .AsNoTracking()
            .Include(c => c.Task)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task Add(Comment newComment)
    {
        await _db.Comments.AddAsync(newComment);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Comment newComment)
    {
        await _db.Comments
            .Where(c => c.Id == newComment.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Description, newComment.Description)
                .SetProperty(c => c.Created, newComment.Created)
                .SetProperty(c => c.AuthorId, newComment.AuthorId)
                .SetProperty(c => c.TaskId, newComment.TaskId)
            );
    }
    
    public async Task Delete(Guid id)
    {
        await _db.Comments.Where(c => c.Id == id).ExecuteDeleteAsync();
    }
}