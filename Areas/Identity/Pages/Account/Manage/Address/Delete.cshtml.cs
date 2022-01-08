#nullable disable
using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Areas.Identity.Pages.Account.Manage.Address
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserAddress UserAddress { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserAddress = await _context.UserAddresses.FirstOrDefaultAsync(m => m.Id == id);

            if (UserAddress == null)
            {
                return NotFound();
            }
            UserAddress.Country = _context.Countries.Single(c => c.Id == UserAddress.CountryId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserAddress = await _context.UserAddresses.FindAsync(id);

            if (UserAddress != null)
            {
                _context.UserAddresses.Remove(UserAddress);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
