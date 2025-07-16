using Mapster;
using SmartTracker.Services.Dtos.WorkTaskDtos;
using SmartTraсker.Data.Abstractions;
using SmartTraсker.Data.Models;

namespace SmartTracker.Services.Services;

public class WorkTaskService(
    IWorkTaskRepository workTaskRepository,
    IUsersRepository usersRepository
    )
{
    public async Task<List<WorkTaskAllWithIdDto>> GetWorkTasks()
    {
        return (await workTaskRepository.Get())
            .Select(t => t.Adapt<WorkTaskAllWithIdDto>())
            .ToList();
    }
    
    public async Task<WorkTaskAllWithIdDto?> GetWorkTaskById(Guid taskId)
    {
        return (await workTaskRepository.GetByIdWithAll(taskId))?
            .Adapt<WorkTaskAllWithIdDto>();
    }

    public async Task<Guid?> CreateWorkTask(WorkTaskCreateDto workTask)
    {
        var author = await usersRepository.GetById(workTask.AuthorId);

        if (author == null)
        {
            throw new NullReferenceException("Author could not be found");
        }
        
        var workTaskNew = workTask.Adapt<WorkTask>();
        workTaskNew.Id = Guid.NewGuid();
        
        await workTaskRepository.Add(workTaskNew);
        return workTaskNew.Id;
    }

    public async Task<WorkTaskBaseDto?> ChangeStatus(WorkTaskStatusDto workTaskStatusDto)
    {
        var task = await workTaskRepository.GetById(workTaskStatusDto.workTaskId);

        if (task == null)
        {
            throw new NullReferenceException("Task could not be found");
        }

        task.Status = workTaskStatusDto.newStatus;
        await workTaskRepository.Update(task);
        
        return task.Adapt<WorkTaskBaseDto>();
    }
    
    public async Task<WorkTaskBaseDto?> ChangePriority(WorkTaskPriorityDto workTaskPriorityDto)
    {
        var task = await workTaskRepository.GetById(workTaskPriorityDto.workTaskId);

        if (task == null)
        {
            throw new NullReferenceException("Task could not be found");
        }

        task.Priority = workTaskPriorityDto.newPriority;
        await workTaskRepository.Update(task);
        
        return task.Adapt<WorkTaskBaseDto>();
    }

    public async Task<WorkTaskAllWithIdDto?> AssignExecutor(ExecutorDto executorDto)
    {
        var task = await workTaskRepository.GetById(executorDto.workTaskId);
        var executor = await usersRepository.GetById(executorDto.userId);

        if (task == null)
        {
            throw new NullReferenceException("Task could not be found");
        }

        if (executor == null)
        {
            throw new NullReferenceException("Executor could not be found");
        }

        task.ExecutorId = executorDto.userId;
        task.Executor = executor;
        await workTaskRepository.Update(task);
        
        return task.Adapt<WorkTaskAllWithIdDto>();
    }

    public async Task<WorkTaskBaseDto?> UpdateInfo(WorkTaskUpdateDto newWorkTask)
    {
        var task = await workTaskRepository.GetById(newWorkTask.Id);
        
        if (task == null)
        {
            throw new NullReferenceException("Task could not be found");
        }
        
        task.Name = newWorkTask.Name;
        task.Description = newWorkTask.Description;
        task.Deadline = newWorkTask.Deadline;
        
        await workTaskRepository.Update(task);
        return task.Adapt<WorkTaskBaseDto>();
    }

    public async Task<WorkTaskAllWithIdDto?> Delete(Guid taskId)
    {
        var task = await workTaskRepository.GetById(taskId);
        
        if (task == null)
        {
            throw new NullReferenceException("Task could not be found");
        }

        await workTaskRepository.Delete(taskId);
        return task.Adapt<WorkTaskAllWithIdDto>();
    }
}