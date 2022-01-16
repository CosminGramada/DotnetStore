using DotnetStore.Data;
using DotnetStore.Models;
using DotnetStore.Pages.Admin.Products;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Pages.Collections;

public class Sale : ProductPageModel
{
    public Sale(ApplicationDbContext context) : base(context)
    {
    }

    public List<Product> Products { get; set; }

    public async Task OnGetAsync()
    {
        var products = await _context.Products
            .OrderByDescending(o => o.UpdatedAt)
            .Include(p => p.Category)
            .Include(p => p.Discount)
            .Include(p => p.ProductImage)
            .ToListAsync();

        Products = products.Select(s =>
            {
                s.Quantity = GetProductQuantity(s);
                s.DiscountedPrice = GetDiscountedPrice(s);
                return s;
            })
            .Where(p => p.Price != p.DiscountedPrice && p.Quantity > 0)
            .ToList();
    }
}