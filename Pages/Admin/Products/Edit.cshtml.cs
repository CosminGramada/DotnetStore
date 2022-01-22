#nullable disable
using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Pages.Admin.Products
{
    [Authorize(Roles = "Admin")]
    public class EditModel : ProductPageModel
    {
        public EditModel(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment): 
            base(context, webHostEnvironment)
        {
        }

        [BindProperty] public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Discount)
                .Include(p => p.ProductImage).FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["DiscountId"] = new SelectList(_context.Discounts, "Id", "Name");
            ViewData["ProductImageId"] = new SelectList(_context.ProductImages, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var product = _context.Products.AsNoTracking().Single(p => p.Id == Product.Id);
            if (Product.ImageFile != null)
            {
                Product.ProductImageId = await UploadImage(Product);
            }
            else
            {
                Product.ProductImageId = product.ProductImageId;
            }
            
            _context.Attach(Product).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.Id))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}