using DotnetStore.Data;
using DotnetStore.Models;
using DotnetStore.Pages.Admin.Products;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Pages.Collections;

public class Men : ProductPageModel
{
    public Men(ApplicationDbContext context): base(context)
    {
    }
    
    public List<Product> Products { get; set; }
    
    public async Task OnGetAsync()
    {
        var menCategory = _context.Categories.Single(c => c.Name == "Men");
        var products = await _context.Products
            .Where(p => p.CategoryId == menCategory.Id)
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