using SmartTracker.API.DTOs;
using SmartTracker.Services.Abstractions;

namespace SmartTracker.API.Controllers;

public static class AuthApi
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        var authGroup = app.MapGroup("api/auth");

        authGroup.MapPost("/Registration", async (UserRegisterDto registerData, IAuthService authService) =>
        {
            try
            {
                await authService.Register(
                    registerData.Name,
                    registerData.Surname,
                    registerData.Username,
                    registerData.Password
                );
            
                return Results.Ok();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });

        authGroup.MapPost("/Login", async (UserLoginDto loginData, IAuthService authService) =>
        {
            try
            {
                string jwtToken = await authService.Login(
                    loginData.Username,
                    loginData.Password
                );

                return Results.Ok(new
                {
                    type = "minimal api",
                    token = jwtToken
                });
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });
    }
}