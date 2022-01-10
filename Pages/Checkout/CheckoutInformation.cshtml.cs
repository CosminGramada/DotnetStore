using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DotnetStore.Pages.Checkout;

public class CheckoutInformation : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    
    public CheckoutInformation(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _signInManager = signInManager;
        _userManager = userManager;
    }
    
    public UserAddress UserAddress { get; set; }
    
    public async Task<IActionResult> OnGetAsync()
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
            var sessionUserAddress = HttpContext.Session.GetString("UserAddress");
            if (sessionUserAddress != null)
            {
                UserAddress = JsonConvert.DeserializeObject<UserAddress>(HttpContext.Session.GetString("UserAddress"));    
            }
        }
        
        return Page();
    }
}