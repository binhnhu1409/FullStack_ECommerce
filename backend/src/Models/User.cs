namespace backend.src.Models;

using System.ComponentModel.DataAnnotations;

public class User : BaseModel
{
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [Required(ErrorMessage = "The email address is required")]
    public string Email { get; set; } = null!;
    public string Avatar {get; set;} = null!;

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName
    {
        get => $"{FirstName} {LastName}";
    }

    public string Password { get; set; } = null!;
    public Role Role { get; set;}
    public Guid? AddressId { get; set; }
    public Cart Cart { get; set; } = null!;
}

public enum Role
{
    Customer, 
    Admin
}
