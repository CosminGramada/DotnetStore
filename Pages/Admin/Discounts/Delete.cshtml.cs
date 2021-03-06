#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Authorization;

namespace DotnetStore.Pages.Admin.Discounts
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly DotnetStore.Data.ApplicationDbContext _context;

        public DeleteModel(DotnetStore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Discount Discount { get; set; }

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Discount = await _context.Discounts.FindAsync(id);

            if (Discount != null)
            {
                _context.Discounts.Remove(Discount);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
