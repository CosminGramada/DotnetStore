using System.ComponentModel.DataAnnotations;
using DotnetStore.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DotnetStore.Models;

public class Order: BaseEntity
{
    [Required]
    public Guid Id { get; set; }
    
    public Guid? UserId { get; set; }
    
    [BindNever]
    public virtual ApplicationUser? User { get; set; }
    
    public OrderStatus OrderStatus { get; set; }
    
    [Required]
    public decimal Total { get; set; }
    
    [Required]
    public string ShippingMethod { get; set; }
    
    [Required]
    public decimal ShippingRate { get; set; }
    
    public string? Note { get; set; }
}