#nullable disable
using System.Security.Claims;
using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Areas.Identity.Pages.Account.Manage.Address
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UserAddress> UserAddresses { get;set; }

        public async Task OnGetAsync()
        {
            var userAddresses = await _context
                .UserAddresses
                .Where(ua =>
                    ua.UserId == Guid.Parse((ReadOnlySpan<char>) User.FindFirstValue(ClaimTypes.NameIdentifier)))
                .OrderByDescending(ua => ua.IsDefault)
                .ThenByDescending(ua => ua.CreatedAt)
                .ToListAsync();
            
            UserAddresses = userAddresses
                .Select(ua =>
                {
                    ua.Country = _context.Countries.Single(c => c.Id == ua.CountryId);
                    return ua;
                }).ToList();

        }
    }
}
