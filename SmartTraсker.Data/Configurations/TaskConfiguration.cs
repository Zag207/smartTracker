using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTraсker.Data.Models;
using Task = SmartTraсker.Data.Models.Task;

namespace SmartTraсker.Data.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(t => t.Author)
            .WithMany(u => u.CreatedTasks)
            .HasForeignKey(t => t.AuthorId);
        
        builder
            .HasOne(t => t.Executor)
            .WithMany(u => u.AssignedTasks)
            .HasForeignKey(t => t.ExecutorId);

        builder
            .HasMany(t => t.Comments)
            .WithOne(c => c.Task);
    }
}