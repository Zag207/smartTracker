using Mapster;
using SmartTracker.Services.Dtos.UserDtos;
using SmartTraсker.Data.Abstractions;

namespace SmartTracker.Services.Services;

public class UserService(
    IUsersRepository usersRepository,
    RolesNames roles
    )
{
    public async Task<List<UserAllWithIdDto>> GetUsers()
    {
        var users = await usersRepository.GetWithAll();
        
        return users
            .Select(u => u.Adapt<UserAllWithIdDto>())
            .ToList();
    }

    public async Task<List<UserAllWithIdDto>> GetUsersWithRoles(string role)
    {
        var users = await usersRepository.GetWithRole();
        
        return users
            .Where(u => u.Role.Name == role)
            .Select(u => u.Adapt<UserAllWithIdDto>())
            .ToList();
    }

    public async Task<UserAllWithIdDto?> GetUserById(Guid userId)
    {
        var user = await usersRepository.GetByIdWithAll(userId);

        if (user == null)
        {
            throw new NullReferenceException($"User with id {userId} not found");
        }
        
        return user.Adapt<UserAllWithIdDto>();
    }

    public async Task<UserBaseDto?> ChangeRole(Guid userId, string roleName)
    {
        var user = await usersRepository.GetByIdWithRole(userId);
        Guid? roleId = roles.GetRole(roleName);

        if (user == null)
        {
            throw new NullReferenceException($"User with id {userId} not found");
        }
        if (user.Role.Name == "Admin")
        {
            throw new Exception("Cannot change role");
        }

        if (roleId == null)
        {
            throw new NullReferenceException($"Role {roleName} not found");
        }
        
        user.RoleId = roleId.Value;
        user.Role.Id = roleId.Value;
        user.Role.Name = roleName;
        
        await usersRepository.Update(user);
        
        return user.Adapt<UserBaseDto>();
    }

    public async Task<UserBaseDto> Update(UserUpdateDto newUser)
    {
        var user = await usersRepository.GetById(newUser.Id);

        if (user == null)
        {
            throw new NullReferenceException($"User with id {newUser.Id} not found");
        }
        
        user.Name = newUser.Name;
        user.Surname = newUser.Surname;
        user.UserName = newUser.UserName;
        
        await usersRepository.Update(user);
        
        return user.Adapt<UserBaseDto>();
    }

    public async Task<UserAllDto> Delete(Guid userId)
    {
        var user = await usersRepository.GetByIdWithAll(userId);
        
        if (user == null)
        {
            throw new NullReferenceException($"User with id {userId} not found");
        }

        if (user.Role.Name == "Admin")
        {
            throw new Exception("Cannot delete user: access denied");
        }

        await usersRepository.DeleteById(userId);
        return user.Adapt<UserAllDto>();
    }
}