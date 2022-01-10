namespace DotnetStore.Models;

public class SessionCart
{
    public Guid ShoppingSessionId { get; set; }
    public Product Product { get; set; }
    public ProductVariant ProductVariant { get; set; }
    public ProductSize ProductSize { get; set; }
    public ProductColor ProductColor { get; set; }
    public int Quantity { get; set; }
}