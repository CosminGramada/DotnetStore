using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DotnetStore.Models;

[Serializable]
public class UserAddress: BaseEntity
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public Guid UserId { get; set; }
    
    [Required]
    [Display(Name = "First name")]
    public string FirstName { get; set; }
    
    [Required]
    [Display(Name = "Last name")]
    public string LastName { get; set; }
    
    [Required]
    [Display(Name = "Address")]
    public string Address1 { get; set; }
    
    [Display(Name = "Apartment / Suite")]
    public string Address2 { get; set; }
    
    [Required]
    public string City { get; set; }

    [Required]
    public Guid CountryId { get; set; }

    [Required]
    public string Zip { get; set; }
    
    [Required]
    [Display(Name = "Phone number")]
    [Phone]
    public string PhoneNumber { get; set; }
    
    [Display(Name = "Set as default address")]
    public bool IsDefault { get; set; }

    [BindNever]
    public virtual Country? Country { get; set; }
    
    [BindNever]
    public virtual ApplicationUser? User { get; set; }
}