using System.ComponentModel.DataAnnotations;

namespace SmartTracker.Services.Dtos.CommentDtos;

public class CommentBaseDto
{
    [MaxLength(250)]
    public string Description { get; set; } = "";
   
    public required DateTime Created { get; set; }
   
    public required Guid AuthorId { get; set; }
    public required Guid TaskId { get; set; }
}

public class CommentWithIdDto : CommentBaseDto
{
    public required Guid Id { get; set; }
}
