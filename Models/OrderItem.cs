using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DotnetStore.Models;

public class OrderItem: BaseEntity
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public Guid OrderId { get; set; }
    
    [BindNever]
    public Order? Order { get; set; }
    
    [Required]
    public Guid ProductId { get; set; }
    
    [BindNever]
    public Product? Product { get; set; }
    
    [Required]
    public Guid ProductColorId { get; set; }
    
    [BindNever]
    public ProductColor? ProductColor { get; set; }
    
    [Required]
    public Guid ProductSizeId { get; set; }
    
    [BindNever]
    public ProductSize? ProductSize { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public int Quantity { get; set; }
}