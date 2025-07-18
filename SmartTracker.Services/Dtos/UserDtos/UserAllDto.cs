using SmartTracker.Services.Dtos.CommentDtos;
using SmartTracker.Services.Dtos.WorkTaskDtos;

namespace SmartTracker.Services.Dtos.UserDtos;

public class UserAllDto : UserBaseDto
{
    public List<WorkTaskAllWithIdDto> CreatedTasks { get; set; } = [];
    public List<WorkTaskAllWithIdDto> AssignedTasks { get; set; } = [];
    public List<CommentAllWithIdDto> Comments { get; set; } = [];
}

public class UserAllWithIdDto : UserAllDto
{
    public required Guid Id { get; set; }
}