using SmartTraсker.Data.Models;

namespace SmartTraсker.Data.Abstractions;

public interface ICommentsRepository
{
    public Task<List<Comment>> Get();
    public Task<Comment?> GetById(Guid id);
    public Task<List<Comment>> GetByTaskId(Guid taskId);
    public Task<List<Comment>> GetByAuthorId(Guid authorId);
    public Task<List<Comment>> GetWithAuthor();
    public Task<Comment?> GetByIdWithAuthor(Guid id);
    public Task<List<Comment>> GetWithTask();
    public Task<Comment?> GetByIdWithTask(Guid id);
    public Task Add(Comment newComment);
    public Task Update(Comment newComment);
    public Task Delete(Guid id);
}