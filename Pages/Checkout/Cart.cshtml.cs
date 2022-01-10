using DotnetStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DotnetStore.Pages.Checkout;

public class Cart : PageModel
{
    public void OnGet()
    {

    }

    public IActionResult OnPostProductRemove(Guid productVariantId)
    {
        var cartSessionItems =
            JsonConvert.DeserializeObject<List<SessionCart>>(HttpContext.Session.GetString("ShoppingSessionId"));

        var productToRemove = cartSessionItems.Single(s => s.ProductVariant.Id == productVariantId);
        cartSessionItems.Remove(productToRemove);
        HttpContext.Session.SetString("ShoppingSessionId", JsonConvert.SerializeObject(cartSessionItems));

        return RedirectToPage();
    }

    public IActionResult OnPost()
    {
        return RedirectToPage("./CheckoutInformation");
    }
}