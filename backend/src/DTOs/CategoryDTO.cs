namespace backend.src.DTOs;

public class CategoryBaseDTO
{
    public string Name { get; set; } = null!;
    public string Image { get; set; } = null!;
}

public class CategoryReadDto : CategoryBaseDTO
{

}

public class CategoryCreateDto : CategoryBaseDTO
{

}

public class CategoryUpdateDto : CategoryBaseDTO
{
    
}