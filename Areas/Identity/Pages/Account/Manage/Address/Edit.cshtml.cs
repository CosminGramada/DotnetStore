#nullable disable
using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Areas.Identity.Pages.Account.Manage.Address
{
    public class EditModel : AddressPageModel
    {
        public EditModel(ApplicationDbContext context) : base(context)
        {
        }

        [BindProperty]
        public UserAddress UserAddress { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await PopulateCountriesDropDownList(_context);

            UserAddress = await _context.UserAddresses.FirstOrDefaultAsync(m => m.Id == id);

            if (UserAddress == null)
            {
                return NotFound();
            }
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

            _context.Attach(UserAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                await UpdateIsDefault(UserAddress);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAddressExists(UserAddress.Id))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool UserAddressExists(Guid id)
        {
            return _context.UserAddresses.Any(e => e.Id == id);
        }
    }
}
