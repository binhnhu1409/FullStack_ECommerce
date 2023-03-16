namespace backend.src.Database;

using Microsoft.EntityFrameworkCore;
using backend.src.Models;

public static class CartItemConfigExtension
{
    public static void AddCartItemConfig(this ModelBuilder builder) 
    {
        builder.Entity<CartItem>(entity => {
            entity
                .HasOne(e => e.Product)
                .WithMany()
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            entity
                .HasOne(e => e.Cart)
                .WithMany()
                .HasForeignKey(e => e.CartId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}