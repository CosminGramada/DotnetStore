using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DotnetStore.Pages.Checkout;

public class CheckoutShipping : CheckoutPageModel
{
    public CheckoutShipping(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) : 
        base(context, signInManager, userManager)
    {
    }

    [BindProperty]
    public string ShippingMethod { get; set; }
    public List<ShippingOption> ShippingOptions { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        if (!CheckoutPageGuard())
        {
            return RedirectToPage("/");
        }
        
        ShippingOptions = await _context.ShippingOptions.OrderBy(c => c.Rate).ToListAsync();
        
        await GetCheckoutUserInformation();
        CheckoutUserInformation.ShippingMethod = "Free";
        CheckoutUserInformation.ShippingRate = 0;
        HttpContext.Session.SetString("CheckoutInformation", JsonConvert.SerializeObject(CheckoutUserInformation));
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await GetCheckoutUserInformation();
        CheckoutUserInformation.ShippingMethod = ShippingMethod;
        CheckoutUserInformation.ShippingRate = _context.ShippingOptions.Single(s => s.Name == ShippingMethod).Rate;
        HttpContext.Session.SetString("CheckoutInformation", JsonConvert.SerializeObject(CheckoutUserInformation));
        return RedirectToPage("./CheckoutPayment");
    }
}