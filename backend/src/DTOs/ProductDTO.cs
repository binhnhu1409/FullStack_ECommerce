namespace backend.src.DTOs;

public class ProductBaseDTO
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Price { get; set; }
    public int Inventory { get; set; }
}

public class ProductReadDto : ProductBaseDTO
{
    public string Category {get; set;} = null!;
    public ICollection<string> Images {get; set;} = null!;
}

public class ProductCreateDto : ProductBaseDTO
{
    public ICollection<string> Images {get; set;} = null!;
    public string CategoryId {get; set;} = null!;
}

public class ProductUpdateDto : ProductBaseDTO
{
    public ICollection<string> Images {get; set;} = null!;
    public string CategoryId {get; set;} = null!;
}