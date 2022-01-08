using System.ComponentModel.DataAnnotations;

namespace DotnetStore.Models;

public class Category: BaseEntity
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }
}