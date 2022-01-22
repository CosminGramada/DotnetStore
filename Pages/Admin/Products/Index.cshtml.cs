#nullable disable
using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Pages.Admin.Products
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : ProductPageModel
    {
        public IndexModel(ApplicationDbContext context): base(context)
        {
        }

        public IList<Product> Products { get;set; }

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
                s.ProductImage = _context.ProductImages.Single(pi => pi.Id == s.ProductImageId);
                s.Quantity = GetProductQuantity(s);
                s.DiscountedPrice = GetDiscountedPrice(s);
                return s;
            }).ToList();
        }
    }
}
