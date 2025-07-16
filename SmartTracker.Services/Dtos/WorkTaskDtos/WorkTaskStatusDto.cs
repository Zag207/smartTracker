using SmartTraсker.Data.Models;

namespace SmartTracker.Services.Dtos.WorkTaskDtos;

public record WorkTaskStatusDto(Guid workTaskId, WorkTaskStatus newStatus);