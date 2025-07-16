using SmartTracker.Services.Dtos.CommentDtos;
using SmartTracker.Services.Dtos.UserDtos;
using SmartTraсker.Data.Models;

namespace SmartTracker.Services.Dtos.WorkTaskDtos;

public class WorkTaskAllDto : WorkTaskBaseDto
{
    public UserWithIdDto? Executor { get; set; }
    public UserWithIdDto? Author { get; set; }
    public List<CommentWithIdDto> Comments { get; set; } = [];
}

public class WorkTaskAllWithIdDto : WorkTaskAllDto
{
    public required Guid Id { get; set; }
}