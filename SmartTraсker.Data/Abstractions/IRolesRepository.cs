using SmartTraсker.Data.Models;

namespace SmartTraсker.Data.Abstractions;

public interface IRolesRepository
{
    public Task<List<Role>> Get();
    public Task<List<Role>> GetWithUsers();
    public Task<Role?> GetById(Guid id);
    public Task<Role?> GetByIdWithUsers(Guid id);
    public Task<Role?> GetByName(string roleName);
    public Task Add(Role newRole);
    public Task Update(Role role);
    public Task DeleteById(Guid id);
}