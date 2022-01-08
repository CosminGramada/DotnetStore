using System.ComponentModel.DataAnnotations;

namespace DotnetStore.Models;

public class Region
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public Guid CountryId { get; set; }

    [Required]
    public string Name { get; set; }
}