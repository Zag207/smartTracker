using SmartTracker.Services.Dtos.UserDtos;
using SmartTracker.Services.Dtos.WorkTaskDtos;

namespace SmartTracker.Services.Dtos.CommentDtos;

public class CommentAllDto : CommentBaseDto
{
    public UserWithIdDto? Author { get; set; }
    public WorkTaskWithIdDto? Task { get; set; }
}

public class CommentAllWithIdDto : CommentAllDto
{
    public required Guid Id { get; set; }
}
