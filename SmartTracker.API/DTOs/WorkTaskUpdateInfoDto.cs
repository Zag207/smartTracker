using SmartTraсker.Data.Models;

namespace SmartTracker.API.DTOs;

public class WorkTaskUpdateInfoDto
{
    public required string Name { get; set; }
    
    public string Description { get; set; } = "";
    
    public required WorkTaskStatus Status { get; set; }
    public required WorkTaskPriority Priority { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime Deadline { get; set; }
}