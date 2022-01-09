#nullable disable
using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Pages.Admin.Products
{
    public class DetailsModel : ProductPageModel
    {
        public DetailsModel(ApplicationDbContext context): base(context)
        {
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Discount)
                .Include(p => p.ProductImage)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (Product == null)
            {
                return NotFound();
            }
            
            Product.Quantity = GetProductQuantity(Product);
            Product.DiscountedPrice = GetDiscountedPrice(Product);
            
            return Page();
        }
    }
}
