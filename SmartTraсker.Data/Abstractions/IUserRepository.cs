using SmartTraсker.Data.Models;

namespace SmartTraсker.Data.Abstractions;

public interface IUsersRepository
{
    public Task<List<User>> Get();
    public Task<List<User>> GetWithAll();
    public Task<User?> GetById(Guid id);
    public Task<User?> GetByIdWithAll(Guid id);
    public Task<User?> GetByUserName(string userName);
    public Task<List<User>> GetByRoleId(Guid roleId);
    public Task<List<User>> GetWithCreatedTasks();
    public Task<List<User>> GetWithAssignedTasks();
    public Task<List<User>> GetWithComments();
    public Task<User?> GetByIdWithCreatedTasks(Guid id);
    public Task<User?> GetByIdWithAssignedTasks(Guid id);
    public Task<User?> GetByIdWithComments(Guid id);
    public Task<User?> GetByIdWithRole(Guid id);
    public Task<List<User>> GetWithRole();
    public Task Add(User newUser);
    public Task Update(User newUser);
    public Task DeleteById(Guid id);
}