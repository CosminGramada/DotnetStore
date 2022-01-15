using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Identity;
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

    public CheckoutModel CheckoutUserInformation { get; set; }

    protected async Task GetCheckoutUserInformation()
    {
        if (_signInManager.IsSignedIn(User))
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userAddress = _context
                .UserAddresses
                .Single(u => u.UserId == user.Id && u.IsDefault);
            CheckoutUserInformation = (CheckoutModel) userAddress;
        }
        else
        {
            var sessionUserAddress = HttpContext.Session.GetString("CheckoutInformation");
            if (sessionUserAddress != null)
            {
                CheckoutUserInformation = JsonConvert.DeserializeObject<CheckoutModel>(HttpContext.Session.GetString("CheckoutInformation"));
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