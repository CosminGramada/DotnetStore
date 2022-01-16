using DotnetStore.Data;
using DotnetStore.Helpers;
using DotnetStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Pages.Checkout;

public class OrderDetails : CheckoutPageModel
{
    public OrderDetails(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager) :
        base(context, signInManager, userManager)
    {
    }

    public List<OrderItem> OrderItems { get; set; }
    public UserAddress UserAddress { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        await GetCheckoutUserInformation();
        UserAddress = CheckoutUserInformation;

        var orderItems = await _context
            .OrderItems
            .Include(oi => oi.Order)
            .Include(oi => oi.Product)
            .Include(oi => oi.ProductColor)
            .Include(oi => oi.ProductSize)
            .Where(oi => oi.OrderId == id)
            .ToListAsync();

        OrderItems = orderItems.AsEnumerable()
            .Select(oi =>
            {
                oi.Product.DiscountedPrice = ProductHelper.GetProductDiscountedPrice(_context, oi.Product);
                return oi;
            })
            .Cast<OrderItem>().ToList();
        
        HttpContext.Session.Clear();
        return Page();
    }
}