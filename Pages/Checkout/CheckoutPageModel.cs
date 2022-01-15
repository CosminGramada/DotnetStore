using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DotnetStore.Pages.Checkout;

public class CheckoutPageModel: PageModel
{
    protected readonly ApplicationDbContext _context;
    protected readonly SignInManager<ApplicationUser> _signInManager;
    protected readonly UserManager<ApplicationUser> _userManager;

    public CheckoutPageModel(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public UserAddress UserAddress { get; set; }
    public string GuestEmail { get; set; }

    protected async Task GetUserAddress()
    {
        if (_signInManager.IsSignedIn(User))
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserAddress = _context
                .UserAddresses
                .Single(u => u.UserId == user.Id && u.IsDefault);    
        }
        else
        {
            var sessionUserAddress = HttpContext.Session.GetString("GuestUserAddress");
            if (sessionUserAddress != null)
            {
                UserAddress = JsonConvert.DeserializeObject<UserAddress>(HttpContext.Session.GetString("GuestUserAddress"));
            }
        }
    }

    protected bool CheckoutPageGuard()
    {
        try
        {
            var cartSessionItems =
                JsonConvert.DeserializeObject<List<SessionCart>>(HttpContext.Session.GetString("ShoppingSessionId"));
            if (cartSessionItems != null && cartSessionItems.Count == 0 )
            {
                return false;
            }
        }
        catch
        {
            return false;
        }

        return true;
    }
}