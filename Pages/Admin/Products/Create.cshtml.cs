#nullable disable
using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotnetStore.Pages.Admin.Products
{
    public class CreateModel : ProductPageModel
    {
        public CreateModel(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment): 
            base(context, webHostEnvironment)
        {
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["DiscountId"] = new SelectList(_context.Discounts, "Id", "Name");
            ViewData["ProductImageId"] = new SelectList(_context.ProductImages, "Id", "Id");
            return Page();
        }

        [BindProperty] public Product Product { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Product.ImageFile != null)
            {
                Product.ProductImageId = await UploadImage(Product);
            }
            else
            {
                Product.ProductImageId = Guid.Parse("00000000-0000-0000-0000-000000000001");
            }
            
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}