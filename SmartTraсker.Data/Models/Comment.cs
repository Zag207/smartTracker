using System.ComponentModel.DataAnnotations;

namespace SmartTraсker.Data.Models;

public class Comment
{
   public Guid Id { get; set; }
   
   [MaxLength(250)]
   public string Description { get; set; } = "";
   
   public required DateTime Created { get; set; } = DateTime.Now;
   
   public required Guid AuthorId { get; set; }
   public required Guid TaskId { get; set; }
   
   public User? Author { get; set; }
   public WorkTask? Task { get; set; }
}