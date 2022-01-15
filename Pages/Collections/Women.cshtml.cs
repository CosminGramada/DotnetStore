using DotnetStore.Data;
using DotnetStore.Models;
using DotnetStore.Pages.Admin.Products;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Pages.Collections;

public class Women : ProductPageModel
{
    public Women(ApplicationDbContext context): base(context)
    {
    }
    
    public List<Product> Products { get; set; }
    
    public async Task OnGetAsync()
    {
        var womenCategory = _context.Categories.Single(c => c.Name == "Women");
        var products = await _context.Products
            .Where(p => p.CategoryId == womenCategory.Id)
            .OrderByDescending(o => o.UpdatedAt)
            .Include(p => p.Category)
            .Include(p => p.Discount)
            .Include(p => p.ProductImage)
            .ToListAsync();
            
        Products = products.Select(s =>
        {
            s.ProductImage = _context.ProductImages.Single(pi => pi.Id == s.ProductImageId);
            s.Quantity = GetProductQuantity(s);
            s.DiscountedPrice = GetDiscountedPrice(s);
            return s;
        }).ToList();
    }
}