#nullable disable
using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Pages.Admin.Products
{
    public class DetailsModel : ProductPageModel
    {
        public DetailsModel(ApplicationDbContext context) : base(context)
        {
        }

        public Product Product { get; set; }
        public SelectList AvailableProductColors { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availableProductColors = await _context
                .ProductVariants
                .Where(v => v.ProductId == id)
                .Join(
                    _context.ProductColors,
                    variant => variant.ProductColorId,
                    color => color.Id,
                    (variant, color) => new {Id = color.Id, Name = color.Name}
                )
                .ToListAsync();

            AvailableProductColors = new SelectList(availableProductColors, "Id", "Name");

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