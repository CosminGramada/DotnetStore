using DotnetStore.Data;
using DotnetStore.Models;

namespace DotnetStore.Helpers;

public class ProductHelper
{
    public static decimal GetProductDiscountedPrice(ApplicationDbContext context, Product product)
    {
        return product.Price - 0.1M;
    }
}