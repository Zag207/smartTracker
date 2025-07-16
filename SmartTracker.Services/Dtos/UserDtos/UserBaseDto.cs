using System.ComponentModel.DataAnnotations;

namespace SmartTracker.Services.Dtos.UserDtos;

public class UserBaseDto
{
    [MaxLength(50)]
    public required string Name { get; set; }
    
    [MaxLength(50)]
    public required string Surname { get; set; }
    
    [MaxLength(50)]
    public required string UserName { get; set; }
    
    public required string RoleName { get; set; }
}

public class UserWithIdDto : UserBaseDto
{
    public required Guid Id { get; set; }
}

public class UserUpdateDto
{
    public required Guid Id { get; set; }
    
    [MaxLength(50)]
    public required string Name { get; set; }
    
    [MaxLength(50)]
    public required string Surname { get; set; }
    
    [MaxLength(50)]
    public required string UserName { get; set; }
}