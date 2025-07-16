using System.ComponentModel.DataAnnotations;

namespace SmartTraсker.Data.Models;

public class User
{
    public Guid Id { get; set; }
    
    [MaxLength(50)]
    public required string Name { get; set; }
    
    [MaxLength(50)]
    public required string Surname { get; set; }
    
    [MaxLength(50)]
    public required string UserName { get; set; }
    
    public required Guid RoleId { get; set; }
    
    public required string PasswordHash { get; set; }

    public Role? Role { get; set; }
    public List<WorkTask> CreatedTasks { get; set; } = [];
    public List<WorkTask> AssignedTasks { get; set; } = [];
    public List<Comment> Comments { get; set; } = [];
}

