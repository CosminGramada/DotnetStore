using System.ComponentModel.DataAnnotations;

namespace DotnetStore.Models;

public class ShippingOption: BaseEntity
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }
    
    [Required]
    public decimal Rate { get; set; }
    
    [Required]
    public string Description { get; set; }
}