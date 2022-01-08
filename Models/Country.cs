using System.ComponentModel.DataAnnotations;

namespace DotnetStore.Models;

public class Country
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }
}