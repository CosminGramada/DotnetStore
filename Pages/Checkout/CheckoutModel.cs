using System.ComponentModel.DataAnnotations;
using DotnetStore.Models;

namespace DotnetStore.Pages.Checkout;

public class CheckoutModel: UserAddress
    {
    public string Email { get; set; }
        
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool CreateAccountFlag { get; set; }
    public string ShippingMethod { get; set; }
    public decimal ShippingRate { get; set; }
}