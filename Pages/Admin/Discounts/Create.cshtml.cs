#nullable disable
using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotnetStore.Pages.Admin.Discounts
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : DiscountPageModel
    {
        public CreateModel(ApplicationDbContext context) : base(context)
        {
        }

        public IActionResult OnGet()
        {
            ViewData["DiscountTypeId"] = new SelectList(_context.DiscountTypes, "Id", "Name");
            return Page();
        }

        [BindProperty] public Discount Discount { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Discount.DiscountType = _context.DiscountTypes.Single(s => s.Id == Discount.DiscountTypeId);
            if (!ModelState.IsValid)
            {
                // var errors = ModelState.Select(x => x.Value.Errors)
                //     .Where(y=>y.Count>0)
                //     .ToList();
                return Page();
            }

            _context.Discounts.Add(Discount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}