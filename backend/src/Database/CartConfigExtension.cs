namespace backend.src.Database;

using Microsoft.EntityFrameworkCore;
using backend.src.Models;

public static class CartConfigExtension
{
    public static void AddCartConfig(this ModelBuilder builder) 
    {
        builder.Entity<Cart>(entity => {
            entity
                .HasOne(e => e.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
