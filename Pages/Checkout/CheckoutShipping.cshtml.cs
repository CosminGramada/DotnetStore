using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Pages.Checkout;

public class CheckoutShipping : CheckoutPageModel
{
    public CheckoutShipping(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) : 
        base(context, signInManager, userManager)
    {
    }

    public async Task<IActionResult> OnGetAsync()
    {
        if (!CheckoutPageGuard())
        {
            return RedirectToPage("/");
        }

        GuestEmail = HttpContext.Session.GetString("GuestEmail");
        await GetUserAddress();

        return Page();
    }
}