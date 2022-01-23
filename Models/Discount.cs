using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using DotnetStore.Data;

namespace DotnetStore.Models;

[Serializable]
public class Discount: BaseEntity, IValidatableObject
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [DisplayName("Discount name")]
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

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (StartDate < DateTime.Now)
        {
            yield return
                new ValidationResult(
                    "Start date cannot be in the past.", 
                    new[] { nameof(StartDate)});
        }
        
        if (EndDate < StartDate)
        {
            yield return
                new ValidationResult(
                    "End date cannot be before the Start date.", 
                    new[] { nameof(EndDate)});
        }

        if (Name.Length > 120)
        {
            yield return
                new ValidationResult(
                    "Discount name cannot be longer than 120 characters.", 
                    new[] { nameof(Name)});
        }
        
        if (Description?.Length > 500)
        {
            yield return
                new ValidationResult(
                    "Discount description cannot be longer than 500 characters.", 
                    new[] { nameof(Description)});
        }

        if (Percent % 1 != 0)
        {
            yield return
                new ValidationResult(
                    "Percent should be an integer.", 
                    new[] { nameof(Percent)});
        }

        if (Percent < 1 || Percent > 99)
        {
            yield return
                new ValidationResult(
                    "Percent should have a value between 1 and 99.", 
                    new[] { nameof(Percent)});
        }

        var context = (ApplicationDbContext) validationContext.GetService(typeof(ApplicationDbContext));
        var discountType = context.DiscountTypes.Single(d => d.Id == DiscountTypeId);

        if (discountType.Name == "Order")
        {
            if (string.IsNullOrWhiteSpace(Code))
            {
                yield return
                    new ValidationResult(
                        "The Code field is required when the Discount Type selected is Order.",
                        new[] {nameof(Code)});
            }
            
            var rgx = new Regex("[^A-Za-z0-9]");
            var hasSpecialChars = rgx.IsMatch(Code);
            if (!hasSpecialChars)
            {
                yield return
                    new ValidationResult(
                        "Code can contain only alpha-numeric characters.", 
                        new[] { nameof(Code)});
            }
        
            if (Code.Length < 6 || Code.Length > 12)
            {
                yield return
                    new ValidationResult(
                        "Code should be between 6 and 12 characters long.", 
                        new[] { nameof(Code)});
            }
        }
        else
        {
            if (!string.IsNullOrWhiteSpace(Code))
            {
                yield return
                    new ValidationResult(
                        "Code should be used only for discounts of type Order", 
                        new[] { nameof(Code)});
            }
        }
    }
}