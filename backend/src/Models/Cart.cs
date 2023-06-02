namespace backend.src.Models;

public class Cart : BaseModel
{
    public Guid? UserId { get; set; } 
    public User User { get; set; } = null!;
}
