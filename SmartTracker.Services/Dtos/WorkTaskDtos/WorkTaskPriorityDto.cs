using SmartTraсker.Data.Models;

namespace SmartTracker.Services.Dtos.WorkTaskDtos;

public record WorkTaskPriorityDto(Guid workTaskId, WorkTaskPriority newPriority);