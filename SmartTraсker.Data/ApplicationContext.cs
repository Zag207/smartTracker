using Microsoft.EntityFrameworkCore;
using SmartTraсker.Data.Configurations;
using SmartTraсker.Data.Models;
using Task = SmartTraсker.Data.Models.Task;

namespace SmartTraсker.Data;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TaskConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}