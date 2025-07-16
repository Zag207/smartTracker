using Microsoft.AspNetCore.Identity;
using SmartTracker.Services.Abstractions;
using SmartTraсker.Data.Abstractions;
using SmartTraсker.Data.Models;

namespace SmartTracker.Services.Services;

public class JwtAuthService(
    IUsersRepository usersRepository,
    RolesNames roles,
    IRolesRepository rolesRepository,
    IJwtService jwtService
    ) : IAuthService
{
    public async Task Register(string name, string surname, string userName, string password)
    {
        var userWithUserName = await usersRepository.GetByUserName(userName);

        if (userWithUserName != null)
        {
            throw new Exception($"User {userWithUserName.UserName} already exists.");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = name,
            Surname = surname,
            UserName = userName,
            PasswordHash = "",
            RoleId = roles.GetRole("Worker") ?? throw new NullReferenceException("Role 'Worker' does not exist.")
        };
        
        string passwordHash = new PasswordHasher<User>().HashPassword(user, password);
        user.PasswordHash = passwordHash;
        
        await usersRepository.Add(user);
    }

    public async Task<string> Login(string username, string password)
    {
        var user = await usersRepository.GetByUserName(username) ?? 
                   throw new Exception("Incorrect username or password.");
        
        var result = new PasswordHasher<User>()
            .VerifyHashedPassword(user, user.PasswordHash, password);

        if (result == PasswordVerificationResult.Failed)
        {
            throw new Exception("Incorrect username or password.");
        }

        user = await usersRepository.GetByIdWithRole(user.Id);
        
        return jwtService.GenerateToken(user);
    }
}