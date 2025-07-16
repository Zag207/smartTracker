using System.ComponentModel.DataAnnotations;

namespace SmartTracker.Services.Dtos.WorkTaskDtos;

public class WorkTaskUpdateDto
{
    public required Guid Id { get; set; }
    
    [MaxLength(60)]
    public required string Name { get; set; }
    
    [MaxLength(250)]
    public string Description { get; set; } = "";
    public required DateTime Deadline { get; set; }
}