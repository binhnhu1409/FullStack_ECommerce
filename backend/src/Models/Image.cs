namespace backend.src.Models;

public class Image : BaseModel
{
    public string Url { get; set; } = null!;

    public Guid? ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public Guid? CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    
    public Guid? UserId { get; set; }
    public User User { get; set; } = null!;
}
