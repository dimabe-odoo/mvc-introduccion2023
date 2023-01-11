using System.ComponentModel.DataAnnotations;

namespace mvc.Models;

public class JobCreateViewModel
{
    [Required]
    [MaxLength(25)]
    [Display(Name = "Nombre del trabajo")]
    public string JobName { get; set; }
    [Required]
    [MaxLength(200)]
    [Display(Name = "Descripción del trabajo")]
    public string JobDescription { get; set; }
}