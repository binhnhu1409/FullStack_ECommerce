namespace backend.src.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName
    {
        get => $"{FirstName} {LastName}";
    }
    public Role Role { get; set;}
    public Guid? AddressId { get; set; }
    public Image Image { get; set; } = null!;
    public Cart Cart { get; set; } = null!;
}

public enum Role
{
    Customer, 
    Admin
}
