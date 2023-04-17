namespace backend.src.DTOs;

public class UserBaseDTO
{
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Avatar {get; set;} = null!;
}

public class UserReadDto : UserBaseDTO 
{
    public string Role {get; set;} = null!;
}

public class UserCreateDto : UserBaseDTO
{
    public string Password {get; set;} = null!;
}

public class UserUpdateDto : UserBaseDTO
{
    public string Password {get; set;} = null!;
}