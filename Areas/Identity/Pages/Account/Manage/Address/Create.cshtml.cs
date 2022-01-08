#nullable disable
using System.Security.Claims;
using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Areas.Identity.Pages.Account.Manage.Address
{
    public class CreateModel : AddressPageModel
    {
        public CreateModel(ApplicationDbContext context) : base(context)
        {
        }
        
        public async Task<IActionResult> OnGet()
        {
            await PopulateCountriesDropDownList(_context);
            return Page();
        }

        [BindProperty] 
        public UserAddress UserAddress { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userAddress = UserAddress;
            userAddress.Id = Guid.NewGuid();
            userAddress.UserId = Guid.Parse((ReadOnlySpan<char>) User.FindFirstValue(ClaimTypes.NameIdentifier));
            userAddress.Country = _context.Countries.Single(c => c.Id == userAddress.CountryId);

            _context.UserAddresses.Add(userAddress);
            await _context.SaveChangesAsync();

            await UpdateIsDefault(userAddress);

            return RedirectToPage("./Index");
        }
    }
}