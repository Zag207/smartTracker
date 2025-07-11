using System.ComponentModel.DataAnnotations;

namespace SmartTraсker.Data.Models;

public enum TaskStatus
{
    Created,
    Assigned,
    InProgress,
    Completed,
    Rejected,
}

public enum TaskPriority
{
    Low,
    Medium,
    High,
    Critical
}

public class Task
{
    public Guid Id { get; set; }
    
    [MaxLength(60)]
    public required string Name { get; set; }
    
    [MaxLength(250)]
    public string Description { get; set; } = "";
    
    public required TaskStatus Status { get; set; }
    public required TaskPriority Priority { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public required DateTime Deadline { get; set; }
    
    public required Guid AuthorId {get; set;}
    public Guid? ExecutorId { get; set; }
    
    public User? Executor { get; set; }
    public User? Author { get; set; }
    public List<Comment> Comments { get; set; } = [];
}