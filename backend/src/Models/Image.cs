namespace backend.src.Models;

public class Image : BaseModel
{
    public string Url { get; set; } = null!;
    public Guid? ProductId { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? UserId { get; set; }
}
