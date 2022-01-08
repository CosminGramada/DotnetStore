using Microsoft.Build.Framework;

namespace DotnetStore.Models;

public class ProductColor: BaseEntity
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }
}