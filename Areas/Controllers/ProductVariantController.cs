using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Areas.Controllers;

public class ProductVariantController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductVariantController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("/Product/GetColors")]
    public JsonResult GetColors()
    {
        return Json(_context.ProductColors);
    }

    [HttpGet]
    [Route("/Product/GetSizes")]
    public JsonResult GetSizes()
    {
        return Json(_context.ProductSizes);
    }

    [HttpGet]
    [Route("/Product/GetProductVariantQuantity")]
    public JsonResult GetProductColors([FromQuery] string productId, [FromQuery] string colorId,
        [FromQuery] string sizeId)
    {
        var productVariant = _context
            .ProductVariants
            .Single(v =>
                v.ProductId == Guid.Parse(productId) &&
                v.ProductColorId == Guid.Parse(colorId) &&
                v.ProductSizeId == Guid.Parse(sizeId)
            );
        return Json(productVariant.Quantity);
    }

    [HttpGet]
    [Route("/Product/GetProductSizes")]
    public async Task<JsonResult> GetProductSizesAsync([FromQuery] string productId, [FromQuery] string colorId)
    {
        var productVariants = await _context
            .ProductVariants
            .Where(v => v.ProductId == Guid.Parse(productId) && v.ProductColorId == Guid.Parse(colorId))
            .Join(_context.ProductSizes,
                variant => variant.ProductSizeId,
                size => size.Id,
                (variant, size) => new {Id = size.Id, Name = size.Name})
            .ToListAsync();
        return Json(productVariants);
    }
}