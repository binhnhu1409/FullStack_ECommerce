namespace backend.src.Models;

public class Image : BaseModel
{
    public string Url { get; set; } = null!;

    public Guid? ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
