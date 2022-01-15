using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotnetStore.Pages.Checkout;

public class CheckoutPayment : CheckoutPageModel
{
    public CheckoutPayment(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) : 
        base(context, signInManager, userManager)
    {
    }
    
    public async Task<IActionResult> OnGetAsync()
    {
        await GetCheckoutUserInformation();
        return Page();
    }
}