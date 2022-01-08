using DotnetStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetStore.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added || e.State == EntityState.Modified)
            );

        foreach (var entityEntry in entries)
        {
            var timestamp = DateTime.Now;
            ((BaseEntity)entityEntry.Entity).UpdatedAt = timestamp;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity) entityEntry.Entity).CreatedAt = timestamp;
            }
            else
            {
                entityEntry.Property(nameof(BaseEntity.CreatedAt)).IsModified = false;
                ((BaseEntity) entityEntry.Entity).CreatedAt = ((BaseEntity) entityEntry.Entity).CreatedAt;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<UserAddress> UserAddresses { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductColor> ProductColors { get; set; }
    public DbSet<ProductSize> ProductSizes { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<DiscountType> DiscountTypes { get; set; }
    public DbSet<Discount> Discounts { get; set; }
}