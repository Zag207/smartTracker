using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SmartTraсker.Data.Models;

public class Role
{
    public Guid Id { get; set; }
    
    [MaxLength(50)]
    public required string Name { get; set; }
    
    public List<User> Users { get; set; } = [];
}