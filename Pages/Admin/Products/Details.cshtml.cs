#nullable disable
using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
        
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            Product = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Discount)
                .Include(p => p.ProductImage)
                .Single(s => s.Id == id);
            Product.DiscountedPrice = GetDiscountedPrice(Product);

            var productColorId = Guid.Parse(Request.Form["color"]);
            var productSizeId = Guid.Parse(Request.Form["size"]);
            var quantity = Convert.ToInt32(Request.Form["quantity"]);

            var productVariant = _context
                .ProductVariants
                .Include(v => v.ProductColor)
                .Include(v => v.ProductSize)
                .Include(v => v.Product)
                .Single(v =>
                    v.ProductId == id &&
                    v.ProductColorId == productColorId &&
                    v.ProductSizeId == productSizeId
                );

            if (quantity <= productVariant.Quantity)
            {
                if (HttpContext.Session.GetString("ShoppingSessionId") == null)
                {
                    HttpContext.Session.SetString("ShoppingSessionId", JsonConvert.SerializeObject(new List<SessionCart>()));
                }

                var sessionCartItems =
                    JsonConvert.DeserializeObject<List<SessionCart>>(
                        HttpContext.Session.GetString("ShoppingSessionId"));

                var currentCartItem = sessionCartItems.FirstOrDefault(c =>
                    c.ProductVariant.Id == productVariant.Id
                );
                if (currentCartItem == null)
                {
                    sessionCartItems.Add(
                        new SessionCart
                        {
                            ShoppingSessionId = Guid.NewGuid(),
                            Product = Product,
                            ProductVariant = productVariant,
                            ProductColor = _context.ProductColors.Single(s => s.Id == productColorId),
                            ProductSize = _context.ProductSizes.Single(s => s.Id == productSizeId),
                            Quantity = quantity
                        }
                    );
                }
                else
                {
                    currentCartItem.Quantity += quantity;
                }

                HttpContext.Session.SetString("ShoppingSessionId", JsonConvert.SerializeObject(sessionCartItems));
                var abc = JsonConvert.DeserializeObject<List<SessionCart>>(
                    HttpContext.Session.GetString("ShoppingSessionId"));
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

            return Page();
        }
    }
}