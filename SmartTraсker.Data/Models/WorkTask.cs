using System.ComponentModel.DataAnnotations;

namespace SmartTraсker.Data.Models;

public enum WorkTaskStatus
{
    Created, 
    InProgress,
    Completed,
    Rejected,
}

public enum WorkTaskPriority
{
    Critical,
    High,
    Medium,
    Low
}

public class WorkTask
{
    public Guid Id { get; set; }
    
    [MaxLength(60)]
    public required string Name { get; set; }
    
    [MaxLength(250)]
    public string Description { get; set; } = "";

    public required WorkTaskStatus Status { get; set; } = WorkTaskStatus.Created;
    public required WorkTaskPriority Priority { get; set; }
    public required DateTime CreatedAt { get; set; } = DateTime.Now;
    public required DateTime Deadline { get; set; }
    
    public required Guid AuthorId {get; set;}
    public Guid? ExecutorId { get; set; }
    
    public User? Executor { get; set; }
    public User? Author { get; set; }
    public List<Comment> Comments { get; set; } = [];
}