using Microsoft.EntityFrameworkCore;
using SmartTraсker.Data.Configurations;
using SmartTraсker.Data.Models;

namespace SmartTraсker.Data.Repositories.EF;

public class ApplicationContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<WorkTask> WorkTasks { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new WorkTaskConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}