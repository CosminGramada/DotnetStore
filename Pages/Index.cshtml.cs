using DotnetStore.Data;
using DotnetStore.Helpers;
using DotnetStore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Pages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ApplicationDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public int WomenProductsCount { get; set; }
    public int MenProductsCount { get; set; }
    public int UnisexProductsCount { get; set; }
    public List<Product> FeaturedProducts { get; set; }

    public async Task OnGetAsync()
    {
        var products = await _context
            .Products
            .Include(p => p.Category)
            .Include(p => p.ProductImage)
            .ToListAsync();
        products = products
            .Select(s =>
            {
                s.Quantity = ProductHelper.GetProductQuantity(_context, s);
                s.DiscountedPrice = ProductHelper.GetProductDiscountedPrice(_context, s);
                return s;
            })
            .ToList();

        FeaturedProducts = products.OrderBy(arg => Guid.NewGuid()).Take(6).ToList();

        WomenProductsCount = products.Count(p => p.Category.Name == "Women");
        MenProductsCount = products.Count(p => p.Category.Name == "Men");
        UnisexProductsCount = products.Count(p => p.Category.Name == "Unisex");
    }
}