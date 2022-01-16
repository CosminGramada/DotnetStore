using System.ComponentModel.DataAnnotations;

namespace DotnetStore.Models;

public class CheckoutPaymentInfo
{
    [DataType(DataType.CreditCard)]
    public long CardNumber { get; set; }
    public string CardName { get; set; }
    public int ExpiryMonth { get; set; }
    public int ExpiryYear { get; set; }
    
    [Range(100, 999, ErrorMessage = "Please enter a valid cvv number")]
    public int Cvv { get; set; }
}