namespace backend.src.DTOs;

public class ImageBaseDTO
{
    public string Url { get; set; } = null!;
}

public class ImageReadDto : ImageBaseDTO
{

}

public class ImageCreateDto : ImageBaseDTO
{

}

public class ImageUpdateDto : ImageBaseDTO
{
    
}