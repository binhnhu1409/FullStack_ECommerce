namespace backend.src.Database;

using Microsoft.EntityFrameworkCore;
using backend.src.Models;

public static class CartItemConfigExtension
{
    public static void AddCartItemConfig(this ModelBuilder builder) 
    {
        builder.Entity<CartItem>().HasKey(ci => new { ci.ProductId, ci.CartId});
    }
}