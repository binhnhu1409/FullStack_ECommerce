namespace backend.src.Database;

using Microsoft.EntityFrameworkCore;
using backend.src.Models;

public static class ImageConfigExtension
{
    public static void AddImageConfig(this ModelBuilder builder)
    {
        builder.Entity<Image>(entity => {
            entity
                .HasOne(e => e.Product)
                .WithMany()
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        });
            
    }
}
