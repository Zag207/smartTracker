using System.ComponentModel.DataAnnotations;
using SmartTraсker.Data.Models;

namespace SmartTracker.Services.Dtos.WorkTaskDtos;

public class WorkTaskBaseDto
{
    [MaxLength(60)]
    public required string Name { get; set; }
    
    [MaxLength(250)]
    public string Description { get; set; } = "";
    
    public required WorkTaskStatus Status { get; set; }
    public required WorkTaskPriority Priority { get; set; }
    public required DateTime CreatedAt { get; set; } = DateTime.Now;
    public required DateTime Deadline { get; set; }
    
    public required Guid AuthorId {get; set;}
    public Guid? ExecutorId { get; set; }
}

public class WorkTaskWithIdDto : WorkTaskBaseDto
{
    public required Guid Id { get; set; }
}