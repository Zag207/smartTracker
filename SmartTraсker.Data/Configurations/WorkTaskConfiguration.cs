using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTraсker.Data.Models;

namespace SmartTraсker.Data.Configurations;

public class WorkTaskConfiguration : IEntityTypeConfiguration<WorkTask>
{
    public void Configure(EntityTypeBuilder<WorkTask> builder)
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