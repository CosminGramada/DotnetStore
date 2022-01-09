using System.ComponentModel.DataAnnotations;

namespace DotnetStore.Models;

public class ProductVariant: BaseEntity
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public Guid ProductId { get; set; }
    
    public Product? Product { get; set; }
    
    [Required]
    public Guid ProductSizeId { get; set; }
    public ProductSize? ProductSize { get; set; }
    
    [Required]
    public Guid ProductColorId { get; set; }
    public ProductColor? ProductColor { get; set; }
    
    [Required]
    public int Quantity { get; set; }
}