using Microsoft.EntityFrameworkCore;
using SmartTraсker.Data.Abstractions;
using SmartTraсker.Data.Models;

namespace SmartTraсker.Data.Repositories.EF;

public class UsersRepository(ApplicationContext db) : IUsersRepository
{
    private ApplicationContext _db = db;

    public async Task<List<User>> Get()
    {
        return await _db.Users
            .AsNoTracking()
            .OrderBy(u => u.Surname)
            .ThenBy(u => u.Name)
            .ToListAsync();
    }

    public async Task<List<User>> GetWithAll()
    {
        return await _db.Users
            .AsNoTracking()
            .Include(u => u.CreatedTasks)
            .Include(u => u.AssignedTasks)
            .Include(u => u.Role)
            .Include(u => u.Comments)
            .OrderBy(u => u.Surname)
            .ThenBy(u => u.Name)
            .ToListAsync();
    }

    public async Task<User?> GetById(Guid id)
    {
        return await _db.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User?> GetByIdWithAll(Guid id)
    {
        return await _db.Users
            .AsNoTracking()
            .Include(u => u.CreatedTasks)
            .Include(u => u.AssignedTasks)
            .Include(u => u.Role)
            .Include(u => u.Comments)
            .OrderBy(u => u.Surname)
            .ThenBy(u => u.Name)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetByUserName(string userName)
    {
        return await _db.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserName == userName);
    }

    public async Task<List<User>> GetByRoleId(Guid roleId)
    {
        return await _db.Users
            .AsNoTracking()
            .Where(u => u.RoleId == roleId)
            .OrderBy(u => u.Surname)
            .ThenBy(u => u.Name)
            .ToListAsync();
    }

    public async Task<List<User>> GetWithCreatedTasks()
    {
        return await _db.Users
            .AsNoTracking()
            .Include(u => u.CreatedTasks)
            .OrderBy(u => u.Surname)
            .ThenBy(u => u.Name)
            .ToListAsync();
    }
    
    public async Task<List<User>> GetWithAssignedTasks()
    {
        return await _db.Users
            .AsNoTracking()
            .Include(u => u.AssignedTasks)
            .OrderBy(u => u.Surname)
            .ThenBy(u => u.Name)
            .ToListAsync();
    }

    public async Task<List<User>> GetWithComments()
    {
        return await _db.Users
            .AsNoTracking()
            .Include(u => u.Comments)
            .OrderBy(u => u.Surname)
            .ThenBy(u => u.Name)
            .ToListAsync();
    }

    public async Task<List<User>> GetWithRole()
    {
       return await _db.Users
            .AsNoTracking()
            .Include(u => u.Role)
            .OrderBy(u => u.Surname)
            .ThenBy(u => u.Name)
            .ToListAsync();
    }
    
    public async Task<User?> GetByIdWithCreatedTasks(Guid id)
    {
        return await _db.Users
            .AsNoTracking()
            .Include(u => u.CreatedTasks)
            .Where(u => u.Id == id)
            .OrderBy(u => u.Surname)
            .ThenBy(u => u.Name)
            .FirstOrDefaultAsync();
    }
    
    public async Task<User?> GetByIdWithAssignedTasks(Guid id)
    {
        return await _db.Users
            .AsNoTracking()
            .Include(u => u.AssignedTasks)
            .Where(u => u.Id == id)
            .OrderBy(u => u.Surname)
            .ThenBy(u => u.Name)
            .FirstOrDefaultAsync();
    }

    public async Task<User?> GetByIdWithComments(Guid id)
    {
        return await _db.Users
            .AsNoTracking()
            .Include(u => u.Comments)
            .Where(u => u.Id == id)
            .OrderBy(u => u.Surname)
            .ThenBy(u => u.Name)
            .FirstOrDefaultAsync();
    }

    public async Task<User?> GetByIdWithRole(Guid id)
    {
        return await _db.Users
            .AsNoTracking()
            .Include(u => u.Role)
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task Add(User newUser)
    {
        await _db.Users.AddAsync(newUser);
        await _db.SaveChangesAsync();
    }

    public async Task Update(User newUser)
    {
        await _db.Users
            .Where(u => u.Id == newUser.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(u => u.Name, newUser.Name)
                .SetProperty(u => u.Surname, newUser.Surname)
                .SetProperty(u => u.UserName, newUser.UserName)
                .SetProperty(u => u.RoleId, newUser.RoleId)
                .SetProperty(u => u.PasswordHash, newUser.PasswordHash)
            );
    }

    public async Task DeleteById(Guid id)
    {
        await _db.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
    }
}