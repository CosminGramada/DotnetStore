using System.ComponentModel.DataAnnotations;

namespace DotnetStore.Models;

public class BaseEntity
{
    [Display(Name = "Created at")]
    [DataType(DataType.Date)]
    public DateTime? CreatedAt { get; set; }
    
    [Display(Name = "Updated at")]
    [DataType(DataType.Date)]
    public DateTime? UpdatedAt { get; set; }
}