using System.ComponentModel.DataAnnotations;

namespace mvc.Models.Entities;

public class Job : BaseModel
{
    [Key]
    public int JobId { get; set; }
    [StringLength(maximumLength: 30)]
    [Required]
    public string JobName { get; set; }
    [StringLength(250)]
    [Required]
    public string JobDescription { get; set; }
}