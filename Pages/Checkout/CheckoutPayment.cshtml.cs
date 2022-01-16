using DotnetStore.Areas.Identity.Pages.Account;
using DotnetStore.Data;
using DotnetStore.Enums;
using DotnetStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DotnetStore.Pages.Checkout;

public class CheckoutPayment : CheckoutPageModel
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IUserStore<ApplicationUser> _userStore;
    private readonly ILogger<CheckoutPayment> _logger;

    public CheckoutPayment(
        ApplicationDbContext context,
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager,
        ILogger<CheckoutPayment> logger
    ) : base(context, signInManager, userManager)
    {
        _logger = logger;
    }
    
    [BindProperty]
    public CheckoutPaymentInfo CheckoutPaymentInfo { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        await GetCheckoutUserInformation();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await GetCheckoutUserInformation();
        ApplicationUser user = null;
        if (CheckoutUserInformation.CreateAccountFlag)
        {
            var userService = new UserService(_userManager, _roleManager, _userStore);
            var appUser = new ApplicationUser
            {
                UserName = CheckoutUserInformation.Email,
                Email = CheckoutUserInformation.Email,
                IsAdmin = false,
                FirstName = CheckoutUserInformation.FirstName,
                LastName = CheckoutUserInformation.LastName
            };
            var result = await userService.CreateNewUserAsync(appUser, CheckoutUserInformation.Password);
            if (!result.Succeeded)
            {
                _logger.LogError("Unable to create the user");
            }
            else
            {
                user = await _userManager.FindByEmailAsync(CheckoutUserInformation.Email);    
            }
        }

        var acceptedPaymentList = await _context.Payments.ToListAsync();
        var cardOnFile = acceptedPaymentList.FirstOrDefault(p =>
            p.CardNumber == CheckoutPaymentInfo.CardNumber &&
            string.Equals(p.CardName, CheckoutPaymentInfo.CardName, StringComparison.InvariantCultureIgnoreCase) &&
            (p.ExpiryYear > CheckoutPaymentInfo.ExpiryYear || (p.ExpiryYear == CheckoutPaymentInfo.ExpiryYear &&
                                                               p.ExpiryMonth >= CheckoutPaymentInfo.ExpiryMonth)) &&
            p.Cvv == CheckoutPaymentInfo.Cvv
        );
        var orderStatus = OrderStatus.Created;
        if (cardOnFile == null)
        {
            orderStatus = OrderStatus.PaymentFailed;
        }

        var cartSessionItems =
            JsonConvert.DeserializeObject<List<SessionCart>>(HttpContext.Session.GetString("ShoppingSessionId"));

        var order = new Order
        {
            Id = Guid.NewGuid(),
            User = user,
            OrderStatus = orderStatus,
            UserId = user?.Id,
            Total = (decimal) cartSessionItems.Sum(c => c.Product.DiscountedPrice) + CheckoutUserInformation.ShippingRate,
            ShippingMethod = CheckoutUserInformation.ShippingMethod,
            ShippingRate = CheckoutUserInformation.ShippingRate
        };

        _context.Add(order);

        foreach (var item in cartSessionItems)
        {
            _context.ProductVariants.Single(v =>
                v.Id == item.ProductVariant.Id
            ).Quantity -= item.Quantity;

            _context.Add(new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                Price = (decimal) item.Product.DiscountedPrice,
                ProductId = item.Product.Id,
                ProductColorId = item.ProductColor.Id,
                ProductSizeId = item.ProductSize.Id,
                Quantity = item.Quantity
            });
        }

        await _context.SaveChangesAsync();
        
        HttpContext.Session.Remove("ShoppingSessionId");

        return RedirectToPage("./OrderDetails", new {id = order.Id});
    }
}