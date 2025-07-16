using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTracker.Services.Dtos.WorkTaskDtos;
using SmartTracker.Services.Services;

namespace SmartTracker.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class WorkTaskController(
    WorkTaskService workTaskService
    ) : Controller
{
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<List<WorkTaskAllWithIdDto>>> Get()
    {
        return Ok(await workTaskService.GetWorkTasks());
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Manager, Worker")]
    public async Task<ActionResult<WorkTaskAllWithIdDto?>> GetById(Guid taskId)
    {
        var task = await workTaskService.GetWorkTaskById(taskId);

        if (task == null)
        {
            return BadRequest("Task not found");
        }

        return Ok(task);
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<ActionResult<Guid?>> Create([FromBody]WorkTaskCreateDto newTask)
    {
        try
        {
            return Ok(await workTaskService.CreateWorkTask(newTask));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Authorize(Roles = "Admin, Manager, Worker")]
    public async Task<ActionResult<WorkTaskBaseDto?>> ChangeStatus([FromBody] WorkTaskStatusDto workTaskStatusDto)
    {
        try
        {
            return Ok(await workTaskService.ChangeStatus(workTaskStatusDto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<ActionResult<WorkTaskBaseDto?>> ChangePriority([FromBody] WorkTaskPriorityDto workTaskPriorityDto)
    {
        try
        {
            return Ok(await workTaskService.ChangePriority(workTaskPriorityDto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<ActionResult<WorkTaskBaseDto?>> UpdateInfo([FromBody] WorkTaskUpdateDto newWorkTask)
    {
        try
        {
            return Ok(await workTaskService.UpdateInfo(newWorkTask));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<ActionResult<WorkTaskAllWithIdDto?>> AssignExecutor([FromBody] ExecutorDto executorDto)
    {
        try
        {
            return Ok(await workTaskService.AssignExecutor(executorDto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<ActionResult<WorkTaskAllWithIdDto?>> Delete(Guid taskId)
    {
        try
        {
            return Ok(await workTaskService.Delete(taskId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}