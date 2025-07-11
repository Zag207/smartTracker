using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTraсker.Data.Models;

namespace SmartTraсker.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder
            .HasMany(u => u.CreatedTasks)
            .WithOne(t => t.Author);
        
        builder
            .HasMany(u => u.AssignedTasks)
            .WithOne(t => t.Executor);
        
        builder
            .HasMany(u => u.Comments)
            .WithOne(c => c.Author);
    }
}