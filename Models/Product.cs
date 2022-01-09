using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetStore.Models;

public class Product: BaseEntity
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    [Required]
    public Guid CategoryId { get; set; }
    
    public Category? Category  { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(6, 2)")]
    public decimal Price { get; set; }
    
    public Guid? DiscountId { get; set; }
    
    public Discount? Discount { get; set; }
    
    public Guid? ProductImageId { get; set; }
    
    [NotMapped]
    public IFormFile? ImageFile { get; set; }
    
    [NotMapped]
    public int? Quantity { get; set; }
    
    [NotMapped]
    public decimal? DiscountedPrice { get; set; }

    public ProductImage? ProductImage { get; set; }
}