using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DotnetStore.Data;
using DotnetStore.Areas.Identity.Data;
using DotnetStore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DotnetStoreContext");
builder.Services.AddDbContext<DotnetStoreIdentityDbContext>(options =>
    options.UseSqlServer(connectionString));
var serverVersion = new MySqlServerVersion(new Version(5, 7, 34));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "GetColors",
    pattern: "{controller=Product}/{action=GetColors}"
);

app.MapControllerRoute(
    name: "GetSizes",
    pattern: "{controller=Product}/{action=GetSizes}"
);

app.MapControllerRoute(
    name: "GetProductColors",
    pattern: "{controller=Product}/{action=GetProductColors}"
);

app.MapControllerRoute(
    name: "GetProductSizes",
    pattern: "{controller=Product}/{action=GetProductSizes}"
);

app.MapRazorPages();

app.Run();