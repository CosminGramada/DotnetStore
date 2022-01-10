using DotnetStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace DotnetStore.Areas.Controllers;

public class CartController : Controller
{
    private readonly ApplicationDbContext _context;

    public CartController(ApplicationDbContext context)
    {
        _context = context;
    }
    
}