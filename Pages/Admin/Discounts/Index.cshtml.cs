#nullable disable
using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Pages.Admin.Discounts
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Discount> Discounts { get;set; }

        public async Task OnGetAsync()
        {
            Discounts = await _context.Discounts
                .Include(d => d.DiscountType).ToListAsync();
        }
    }
}
