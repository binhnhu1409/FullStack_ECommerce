namespace backend.src.Models;

public class Product : BaseModel
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? Price { get; set; }
    public int? Inventory { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}