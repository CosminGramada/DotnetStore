using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DotnetStore.Pages.Checkout;

public class CheckoutInformation : CheckoutPageModel
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IUserStore<ApplicationUser> _userStore;
    
    public CheckoutInformation(
        ApplicationDbContext context, 
        SignInManager<ApplicationUser> signInManager, 
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager
        ) : base(context, signInManager, userManager)
    {
    }

    public SelectList Countries { get; set; }
    
    [BindProperty]
    public CheckoutModel CheckoutInfo { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        if (!CheckoutPageGuard())
        {
            return RedirectToPage("/");
        }
        
        var countries = await _context.Countries.ToListAsync();
        Countries = new SelectList(countries, "Id", "Name");

        await GetCheckoutUserInformation();
        CheckoutInfo = CheckoutUserInformation;

        return Page();
    }

    public IActionResult OnPostAsync()
    {
        var guestUserAddress = CheckoutInfo;
        guestUserAddress.Country = _context.Countries.Single(c => c.Id == CheckoutInfo.CountryId);

        HttpContext.Session.SetString("CheckoutInformation", JsonConvert.SerializeObject(guestUserAddress));

        return RedirectToPage("./CheckoutShipping");
    }
}