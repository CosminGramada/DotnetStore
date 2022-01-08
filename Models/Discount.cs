using System.ComponentModel.DataAnnotations;

namespace DotnetStore.Models;

public class Discount: BaseEntity
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public string? Code { get; set; }
    
    [Required]
    public int Percent { get; set; }
    
    public Guid DiscountTypeId { get; set; }
    
    public DiscountType? DiscountType { get; set; }
    
    [Display(Name = "Start date")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    
    [Display(Name = "End date")]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
}