using Microsoft.AspNetCore.Mvc;
using SmartTracker.API.DTOs;
using SmartTracker.Services.Abstractions;

namespace SmartTracker.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController(
    IAuthService authService
    ) : Controller
{
    [HttpPost]
    public async Task<ActionResult> Registration([FromBody]UserRegisterDto registerData)
    {
        try
        {
            await authService.Register(
                registerData.Name,
                registerData.Surname,
                registerData.Username,
                registerData.Password
            );
            
            return Ok();
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<string>> Login([FromBody]UserLoginDto loginData)
    {
        try
        {
            string jwtToken = await authService.Login(
                loginData.Username,
                loginData.Password
            );
            
            return Ok(jwtToken);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}