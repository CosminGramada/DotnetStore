using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Helpers;

public class ProductHelper
{
    public static decimal GetProductDiscountedPrice(ApplicationDbContext context, Product product)
    {
        return product.Price - 0.1M;
    }

    public static int GetProductQuantity(ApplicationDbContext context, Product product)
    {
        var productVariants = context.ProductVariants.Where(v => v.ProductId == product.Id).ToList();
        return productVariants.Sum(v => v.Quantity);
    }
}