using Microsoft.AspNetCore.Identity;

namespace DotnetStore.Models;

public class ApplicationUser: IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsAdmin { get; set; }
}