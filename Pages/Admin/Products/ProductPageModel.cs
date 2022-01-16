using DotnetStore.Data;
using DotnetStore.Helpers;
using DotnetStore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotnetStore.Pages.Admin.Products;

public class ProductPageModel: PageModel
{
    protected readonly ApplicationDbContext _context;
    protected readonly IWebHostEnvironment _webHostEnvironment;

    public ProductPageModel(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public ProductPageModel(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }
    
    protected async Task<Guid> UploadImage(Product product)
    {
        string uniqueFileName = null;
        var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
        var abc = product.ImageFile?.FileName;
        uniqueFileName = Guid.NewGuid() + ".png";
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);
        await using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await product.ImageFile?.CopyToAsync(fileStream)!;
        }

        var productImage = new ProductImage
        {
            Id = Guid.NewGuid(),
            Name = uniqueFileName
        };

        _context.ProductImages.Add(productImage);
        await _context.SaveChangesAsync();

        return productImage.Id;
    }
    
    protected int GetProductQuantity(Product product)
    {
        var productVariants = _context.ProductVariants.Where(v => v.ProductId == product.Id).ToList();
        return productVariants.Sum(v => v.Quantity);
    }
        
    protected decimal GetDiscountedPrice(Product product)
    {
        return ProductHelper.GetProductDiscountedPrice(_context, product);
    }

    protected async Task SaveProductVariantAsync(Guid productId)
    {
        foreach (var item in Request.Form)
        {
            if (item.Key.StartsWith("product_color"))
            {
                var index = item.Key.Substring(item.Key.LastIndexOf("_") + 1);
                
                var productVariant = new ProductVariant
                {
                    ProductId = productId,
                    ProductColorId = Guid.Parse(item.Value),
                    ProductSizeId = Guid.Parse(Request.Form[$"product_size_{index}"]),
                    Quantity = Convert.ToInt32(Request.Form[$"quantity_{index}"])
                };

                _context.ProductVariants.Add(productVariant);
                await _context.SaveChangesAsync();
            }
        }
    }
}