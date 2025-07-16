using SmartTracker.Services.Dtos.WorkTaskDtos;

namespace SmartTracker.Services.Dtos.UserDtos;

public class UserAllDto : UserBaseDto
{
    public List<WorkTaskWithIdDto> CreatedTasks { get; set; } = [];
    public List<WorkTaskWithIdDto> AssignedTasks { get; set; } = [];
    public List<WorkTaskWithIdDto> Comments { get; set; } = [];
}

public class UserAllWithIdDto : UserAllDto
{
    public required Guid Id { get; set; }
}