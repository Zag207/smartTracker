using Mapster;
using SmartTracker.Services.Dtos.CommentDtos;
using SmartTraсker.Data.Abstractions;
using SmartTraсker.Data.Models;

namespace SmartTracker.Services.Services;

public class CommentsService(
    ICommentsRepository commentsRepository,
    IUsersRepository usersRepository,
    IWorkTaskRepository workTaskRepository
    )
{
    public async Task<List<CommentAllWithIdDto>> Get()
    {
        return (await commentsRepository.Get())
            .Select(c => c.Adapt<CommentAllWithIdDto>())
            .ToList();
    }
    
    public async Task<CommentAllWithIdDto?> GetById(Guid commnetId)
    {
        return (await workTaskRepository.GetByIdWithAll(commnetId))?
            .Adapt<CommentAllWithIdDto>();
    }
    
    public async Task<List<CommentAllWithIdDto>> GetByTaskId(Guid taskId)
    {
        var task = await workTaskRepository.GetById(taskId);

        if (task == null)
        {
            throw new NullReferenceException("Task not found");
        }
        
        return (await commentsRepository.GetByTaskId(taskId))
            .Select(c => c.Adapt<CommentAllWithIdDto>())
            .ToList();
    }
    
    public async Task<List<CommentAllWithIdDto>> GetByAuthorId(Guid authorId)
    {
        var author = await usersRepository.GetById(authorId);

        if (author == null)
        {
            throw new NullReferenceException("Author not found");
        }
        
        return (await commentsRepository.GetByAuthorId(authorId))
            .Select(c => c.Adapt<CommentAllWithIdDto>())
            .ToList();
    }

    public async Task<Guid?> Create(CommnetCreateDto newCommnet)
    {
        var author = await usersRepository.GetById(newCommnet.AuthorId);
        var task = await workTaskRepository.GetById(newCommnet.TaskId);

        if (author == null)
        {
            throw new NullReferenceException("Author could not be found");
        }

        if (task == null)
        {
            throw new NullReferenceException("Task not found");
        }
        
        var commentNew = newCommnet.Adapt<Comment>();
        commentNew.Id = Guid.NewGuid();
        
        await commentsRepository.Add(commentNew);
        return commentNew.Id;
    }
    
    public async Task<CommentBaseDto?> Update(CommentChangeDataDto updatedCommnet)
    {
        var comment = await commentsRepository.GetById(updatedCommnet.Id);

        if (comment == null)
        {
            throw new NullReferenceException("Comment could not be found");
        }
        
        comment.Description = updatedCommnet.Description;
        
        await commentsRepository.Update(comment);
        return comment.Adapt<CommentBaseDto>();
    }

    public async Task<CommentAllWithIdDto?> Delete(Guid commentId)
    {
        var comment = await commentsRepository.GetById(commentId);
        
        if (comment == null)
        {
            throw new NullReferenceException("Comment could not be found");
        }

        await commentsRepository.Delete(commentId);
        return comment.Adapt<CommentAllWithIdDto>();
    }
}