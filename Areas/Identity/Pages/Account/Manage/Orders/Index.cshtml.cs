#nullable disable
using System.Security.Claims;
using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Areas.Identity.Pages.Account.Manage.Orders
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Orders { get;set; }

        public async Task OnGetAsync()
        {
            Orders = await _context
                .Orders
                .Where(ua =>
                    ua.UserId == Guid.Parse((ReadOnlySpan<char>) User.FindFirstValue(ClaimTypes.NameIdentifier)))
                .OrderByDescending(o => o.UpdatedAt)
                .ToListAsync();
        }
    }
}
