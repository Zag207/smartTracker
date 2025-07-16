using System.ComponentModel.DataAnnotations;
using SmartTraсker.Data.Models;

namespace SmartTracker.Services.Dtos.WorkTaskDtos;

public class WorkTaskCreateDto
{
    [MaxLength(60)]
    public required string Name { get; set; }
    
    [MaxLength(250)]
    public string Description { get; set; } = "";
    public required WorkTaskPriority Priority { get; set; }
    public required DateTime Deadline { get; set; }
    
    public required Guid AuthorId {get; set;}
}