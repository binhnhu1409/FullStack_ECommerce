namespace backend.src.Database;

using Microsoft.EntityFrameworkCore;
using backend.src.Models;

public static class ImageConfigExtension
{
    public static void AddImageConfig(this ModelBuilder builder)
    {
        builder.Entity<Image>(entity => {
            entity
                .HasOne(e => e.Category)
                .WithMany()
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            entity
                .HasOne(e => e.Product)
                .WithMany()
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            entity
                .HasOne(e => e.User)
                .WithOne(u => u.Image)
                .HasForeignKey<Image>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
            
    }
}
