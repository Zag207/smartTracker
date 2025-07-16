namespace SmartTracker.API.DTOs;

public class ChangeRoleDto
{
    public required Guid UserId { get; set; }
    public required string Name { get; set; }
}