using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetStore.Models;

[Serializable]
public class Product: BaseEntity, IValidatableObject
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
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Name.Length > 120)
        {
            yield return
                new ValidationResult(
                    "Product name cannot be longer than 120 characters.", 
                    new[] { nameof(Name)});
        }
        
        if (Description?.Length > 500)
        {
            yield return
                new ValidationResult(
                    "Discount description cannot be longer than 500 characters.", 
                    new[] { nameof(Description)});
        }

        if (Decimal.Round(Price, 2) != Price)
        {
            yield return
                new ValidationResult(
                    "Price can only have 2 decimals.", 
                    new[] { nameof(Price)});
        }
    }
}