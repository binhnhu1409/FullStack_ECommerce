namespace backend.src.Database;

using Microsoft.EntityFrameworkCore;
using backend.src.Models;

public static class SharedConfigExtension
{
    public static void AddTimestampConfig(this ModelBuilder builder)
    {
        foreach (var entityName in builder.Model.GetEntityTypes().Select(e => e.Name))
        {
            builder.Entity(entityName)
                .Property<DateTime>("CreatedAt")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Entity(entityName)
                .Property<DateTime>("UpdatedAt")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
