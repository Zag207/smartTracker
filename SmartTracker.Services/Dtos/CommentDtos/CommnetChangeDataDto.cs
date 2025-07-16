using System.ComponentModel.DataAnnotations;

namespace SmartTracker.Services.Dtos.CommentDtos;

public class CommnetCreateDto
{
    [MaxLength(250)]
    public string Description { get; set; } = "";
   
    public required Guid AuthorId { get; set; }
    public required Guid TaskId { get; set; }
}