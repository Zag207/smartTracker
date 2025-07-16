using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTracker.API.DTOs;
using SmartTracker.Services.Dtos.UserDtos;
using SmartTracker.Services.Services;

namespace SmartTracker.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController(
    UserService userService
    ) : Controller
{
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UserAllWithIdDto>> GetUsers()
    {
        return Ok(await userService.GetUsers());
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<ActionResult<List<UserAllWithIdDto>>> GetWorkers()
    {
        return Ok(await userService.GetUsersWithRoles("Worker"));
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Manager, Worker")]
    public async Task<ActionResult<UserAllWithIdDto?>> GetUser(Guid userId)
    {
        try
        {
            return Ok(await userService.GetUserById(userId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UserBaseDto?>> ChangeRole([FromBody] ChangeRoleDto role)
    {
        try
        {
            return Ok(await userService.ChangeRole(role.UserId, role.Name));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Authorize(Roles = "Admin, Manager, Worker")]
    public async Task<ActionResult<UserBaseDto>> UpdateUser([FromBody] UserUpdateDto user)
    {
        try
        {
            return Ok(await userService.Update(user));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Authorize(Roles = "Admin, Manager, Worker")]
    public async Task<ActionResult<UserAllDto>> DeleteUser(Guid userId)
    {
        try
        {
            return Ok(await userService.Delete(userId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}