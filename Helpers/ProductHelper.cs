using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Helpers;

public static class ProductHelper
{
    public static decimal GetProductDiscountedPrice(ApplicationDbContext context, Product product)
    {
        var discount = context.Discounts.FirstOrDefault(d => 
            d.Id == product.DiscountId &&
            d.StartDate.CompareTo(DateTime.Now) <= 0 &&
            d.EndDate.CompareTo(DateTime.Now) >= 0 &&
            d.DiscountType.Name == "Product"
        );
        if (discount == null)
        {
            return product.Price;
        }
        
        return product.Price - product.Price * discount.Percent / 100;
    }

    public static int GetProductQuantity(ApplicationDbContext context, Product product)
    {
        var productVariants = context.ProductVariants.Where(v => v.ProductId == product.Id).ToList();
        return productVariants.Sum(v => v.Quantity);
    }
}