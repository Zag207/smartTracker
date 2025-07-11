using System.ComponentModel.DataAnnotations;

namespace SmartTraсker.Data.Models;

public enum Role
{
    Worker,
    Manager,
    Admin
}

public class User
{
    public Guid Id { get; set; }
    
    [MaxLength(50)]
    public required string Name { get; set; }
    
    [MaxLength(50)]
    public required string Surname { get; set; }
    
    public required Role Role { get; set; }
    public required string PasswordHash { get; set; }

    public List<Task> CreatedTasks { get; set; } = [];
    public List<Task> AssignedTasks { get; set; } = [];
    public List<Comment> Comments { get; set; } = [];
}

