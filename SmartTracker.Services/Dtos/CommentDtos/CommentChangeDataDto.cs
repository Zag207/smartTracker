using System.ComponentModel.DataAnnotations;

namespace SmartTracker.Services.Dtos.CommentDtos;

public class CommentChangeDataDto
{
    public required Guid Id { get; set; }
    
    [MaxLength(250)]
    public string Description { get; set; } = "";
}