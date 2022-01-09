using DotnetStore.Data;
using DotnetStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetStore.Areas.Controllers;

public class UploadController : Controller
{
    private readonly ApplicationDbContext _context;  
    private readonly IWebHostEnvironment _webHostEnvironment;  
    public UploadController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)  
    {  
        _context = context;  
        _webHostEnvironment = hostEnvironment;  
    }
    
    [HttpPost]
    [Route("/Upload/UploadImage")]
    public string UploadImage(IFormFile file)
    {
        string uniqueFileName = null;
        var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");  
        uniqueFileName = Guid.NewGuid() + ".png";  
        string filePath = Path.Combine(uploadsFolder, uniqueFileName);  
        using (var fileStream = new FileStream(filePath, FileMode.Create))  
        {  
            file.CopyTo(fileStream);  
        }

        return uniqueFileName;
    }
}