namespace backend.src.Database;

using Microsoft.EntityFrameworkCore;
using backend.src.Models;

public static class ProductConfigExtension
{
    public static void AddProductConfig(this ModelBuilder builder)
    {
        // Create an index on Product properties using Fluent API
        builder.Entity<Product>()
            .HasIndex(p => p.Title);

        builder.Entity<Product>()
            .HasIndex(p => p.Price);

        builder.Entity<Product>()
            .HasOne(e => e.Category)
            .WithMany()
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
