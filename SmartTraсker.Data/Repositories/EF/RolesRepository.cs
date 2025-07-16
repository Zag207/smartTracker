using Microsoft.EntityFrameworkCore;
using SmartTraсker.Data.Abstractions;
using SmartTraсker.Data.Models;

namespace SmartTraсker.Data.Repositories.EF;

public class RolesRepository(ApplicationContext db) : IRolesRepository
{
    private ApplicationContext _db = db;
    
    public async Task<List<Role>> Get()
    {
        return await _db.Roles
            .OrderBy(r => r.Name)
            .ToListAsync();
    }

    public async Task<List<Role>> GetWithUsers()
    {
        return await _db.Roles
            .Include(r => r.Users)
            .OrderBy(r => r.Name)
            .ToListAsync();
    }

    public async Task<Role?> GetById(Guid id)
    {
        return await _db.Roles
            .Where(r => r.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Role?> GetByIdWithUsers(Guid id)
    {
        return await _db.Roles
            .Include(r => r.Users)
            .Where(r => r.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Role?> GetByName(string roleName)
    {
        return await _db.Roles
            .FirstOrDefaultAsync(r => r.Name == roleName);
    }


    public async Task Add(Role newRole)
    {
        await _db.Roles.AddAsync(newRole);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Role role)
    {
        await _db.Roles
            .Where(r => r.Id == role.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(r => r.Name, role.Name));
    }

    public async Task DeleteById(Guid id)
    {
        await _db.Roles
            .Where(r => r.Id == id)
            .ExecuteDeleteAsync();
    }
}