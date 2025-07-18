using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTracker.Services.Dtos.CommentDtos;
using SmartTracker.Services.Services;

namespace SmartTracker.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CommentController(
    CommentsService commnetsService
    ) : Controller
{
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<CommentAllWithIdDto>>> Get()
    {
        return Ok(await commnetsService.Get());
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<CommentAllWithIdDto?>> GetById(Guid commentId)
    {
        try
        {
            return Ok(await commnetsService.GetById(commentId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<CommentAllWithIdDto>>> GetByTaskId(Guid taskId)
    {
        try
        {
            return Ok(await commnetsService.GetByTaskId(taskId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<CommentAllWithIdDto>>> GetByAuthorId(Guid authorId)
    {
        try
        {
            return Ok(await commnetsService.GetByAuthorId(authorId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Guid?>> Create([FromBody] CommnetCreateDto newComment)
    {
        try
        {
            return Ok(await commnetsService.Create(newComment));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Authorize]
    public async Task<ActionResult<CommentBaseDto?>> Update([FromBody] CommentChangeDataDto updatedComment)
    {
        try
        {
            return Ok(await commnetsService.Update(updatedComment));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Authorize]
    public async Task<ActionResult<CommentAllWithIdDto?>> Delete(Guid commentId)
    {
        try
        {
            return Ok(await commnetsService.Delete(commentId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}