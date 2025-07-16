using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTraсker.Data.Models;

namespace SmartTraсker.Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);

        builder
            .HasMany(r => r.Users)
            .WithOne(u => u.Role);
        
        builder
            .HasIndex(r => r.Name)
            .IsUnique();
    }
}