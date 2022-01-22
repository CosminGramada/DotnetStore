#nullable disable
using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Pages.Admin.Discounts
{
    [Authorize(Roles = "Admin")]
    public class EditModel : DiscountPageModel
    {
        public EditModel(ApplicationDbContext context) : base(context)
        {
        }

        [BindProperty] public Discount Discount { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Discount = await _context.Discounts
                .Include(d => d.DiscountType).FirstOrDefaultAsync(m => m.Id == id);

            if (Discount == null)
            {
                return NotFound();
            }

            ViewData["DiscountTypeId"] = new SelectList(_context.DiscountTypes, "Id", "Name");
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

            _context.Attach(Discount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscountExists(Discount.Id))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool DiscountExists(Guid id)
        {
            return _context.Discounts.Any(e => e.Id == id);
        }
    }
}