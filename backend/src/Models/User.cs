namespace backend.src.Models;

using System.ComponentModel.DataAnnotations;

public class User : BaseModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName
    {
        get => $"{FirstName} {LastName}";
    }
    public UserRole Role { get; set;}
    public byte[] Password { get; set; } = null!;
    public byte[] Salt { get; set; } = null!;

    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [Required(ErrorMessage = "The email address is required")]
    public string Email { get; set; } = null!;

    public Guid? AddressId { get; set; }

    public enum UserRole
    {
        Customer, 
        Admin
    }
}
