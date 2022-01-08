using DotnetStore.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Pages.Admin.Discounts;

public class DiscountPageModel: PageModel
{
    protected readonly ApplicationDbContext _context;

    public DiscountPageModel(ApplicationDbContext context)
    {
        _context = context;
    }
    public SelectList DiscountTypes { get; set; }
    
    protected async Task PopulateDiscountTypesDropDownList(object selectedDiscount = null!)
    {
        var discountTypes = await _context.DiscountTypes.ToListAsync();
        DiscountTypes = new SelectList(discountTypes, "Id", "Name", selectedDiscount);
    }
}