namespace backend.src.Database;

using backend.src.Models;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration _config;
    public DbSet<Cart> Carts { get; set; } = null!;
    public DbSet<CartItem> CartItems { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Image> Images { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    
    public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration config) : base(options)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Call the OnConfiguring of the base class
        base.OnConfiguring(optionsBuilder);

        optionsBuilder
            .UseNpgsql(_config.GetConnectionString("DefaultConnection"))
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasPostgresEnum<Role>(); 
        builder.Entity<User>(entity => 
        {
            entity.Property(e => e.Role).HasColumnType("role");
            entity.HasIndex(e => e.Email).IsUnique();
        });

        //Specific entity config with extension methods
        builder.AddProductConfig();
        builder.AddImageConfig();
        builder.AddCartConfig();
        builder.AddTimestampConfig();
    }   
}