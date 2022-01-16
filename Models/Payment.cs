using System.ComponentModel.DataAnnotations;

namespace DotnetStore.Models;

public class Payment: BaseEntity
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public long CardNumber { get; set; }
    
    [Required]
    public string CardName { get; set; }
    
    [Required]
    public int ExpiryMonth { get; set; }
    
    [Required]
    public int ExpiryYear { get; set; }
    
    [Required]
    public int Cvv { get; set; }
}