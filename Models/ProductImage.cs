using Microsoft.Build.Framework;

namespace DotnetStore.Models;

public class ProductImage: BaseEntity
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }
}