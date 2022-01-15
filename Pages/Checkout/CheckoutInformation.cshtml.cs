using DotnetStore.Areas.Identity.Pages.Account;
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

    public async Task<IActionResult> OnGetAsync()
    {
        if (!CheckoutPageGuard())
        {
            return RedirectToPage("/");
        }
        
        var countries = await _context.Countries.ToListAsync();
        if (HttpContext.Session.GetString("GuestUserAddress") != null)
        {
            var userAddress =
                JsonConvert.DeserializeObject<UserAddress>(HttpContext.Session.GetString("GuestUserAddress"));
            Countries = new SelectList(countries, "Id", "Name", userAddress.Country.Id);
            GuestEmail = userAddress.User.Email;
        }
        else
        {
            Countries = new SelectList(countries, "Id", "Name");
            GuestEmail = HttpContext.Session.GetString("GuestEmail");
        }
        
        await GetUserAddress();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var email = Request.Form["email"];
        var password = Request.Form["password"];

        var userService = new UserService(_userManager, _roleManager, _userStore);
        var appUser = new ApplicationUser
        {
            UserName = email, 
            Email = email,
            IsAdmin = false,
            FirstName = Request.Form["first_name"],
            LastName = Request.Form["last_name"]
        };
        
        var guestUserAddress = new UserAddress
        {
            Address1 = Request.Form["address1"],
            Address2 = Request.Form["address2"],
            FirstName = Request.Form["first_name"],
            LastName = Request.Form["last_name"],
            Zip = Request.Form["zip"],
            City = Request.Form["city"],
            Country = _context.Countries.Single(c => c.Id == Guid.Parse(Request.Form["country"])),
            User = await _userManager.FindByEmailAsync(email)
        };

        if (!string.IsNullOrWhiteSpace(password))
        {
            var result = await userService.CreateNewUser(appUser, password);
            if (result.Succeeded)
            {
                guestUserAddress.User = await _userManager.FindByEmailAsync(email);
            }
            else
            {
                GuestEmail = email;
                HttpContext.Session.SetString("GuestEmail", email);    
            }
        }
        else
        {
            GuestEmail = email;
            HttpContext.Session.SetString("GuestEmail", email);    
        }

        HttpContext.Session.SetString("GuestUserAddress", JsonConvert.SerializeObject(guestUserAddress));

        return RedirectToPage("./CheckoutShipping");
    }
}