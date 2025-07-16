using SmartTraсker.Data.Abstractions;
using SmartTraсker.Data.Repositories.EF;

namespace SmartTracker.Services;

public class RolesNames(IRolesRepository rolesRepository)
{
    private readonly Dictionary<string, Guid> _roles = new();

    public async Task InitRoles()
    {
        _roles.Add("Admin", (await rolesRepository.GetByName("Admin"))!.Id);
        _roles.Add("Manager", (await rolesRepository.GetByName("Manager"))!.Id);
        _roles.Add("Worker", (await rolesRepository.GetByName("Worker"))!.Id);
    }

    public Guid? GetRole(string roleName)
    {
        return _roles.ContainsKey(roleName) ? _roles[roleName] : null;
    }
}