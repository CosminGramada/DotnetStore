using System.Security.Claims;
using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Areas.Identity.Pages.Account.Manage.Address;

public class AddressPageModel: PageModel
{
    protected readonly ApplicationDbContext _context;

    public AddressPageModel(ApplicationDbContext context)
    {
        _context = context;
    }
    public SelectList Countries { get; set; }

    protected async Task PopulateCountriesDropDownList(object selectedCountry = null!)
    {
        var countries = await _context.Countries.ToListAsync();
        Countries = new SelectList(countries, "Id", "Name", selectedCountry);
    }

    protected async Task UpdateIsDefault(UserAddress userAddress)
    {
        if (userAddress.IsDefault)
        {
            var userAddresses = await _context
                .UserAddresses
                .Where(ua =>
                    ua.UserId == Guid.Parse((ReadOnlySpan<char>) User.FindFirstValue(ClaimTypes.NameIdentifier)) &&
                    ua.Id != userAddress.Id
                )
                .ToListAsync();

            _context.UserAddresses.UpdateRange(userAddresses.Select(ua =>
            {
                ua.IsDefault = false;
                return ua;
            }));
            await _context.SaveChangesAsync();
        }
    }
}