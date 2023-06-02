namespace backend.src.DTOs;

public class CartItemDTO
{
    public string Title {get; set;} = null!;
    public string Description {get; set;} = null!;
    public int Price {get; set;}
    public int Quantity {get; set;}
    public int TotalPrice 
    {
        get => Quantity * Price;
    }
}
