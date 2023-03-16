namespace backend.src.Models;

public class CartItem : BaseModel
{
    public int? Quantity { get; set; }
    public Guid ProductId { get; set; }
    public Guid CartId { get; set; }
}
