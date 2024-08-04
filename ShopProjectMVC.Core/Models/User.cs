using System.ComponentModel.DataAnnotations;

namespace ShopProjectMVC.Core.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [MinLength(4, ErrorMessage = "Name must be at least 4 characters long.")]
	public string Name { get; set; }

	[Required]
	[EmailAddress(ErrorMessage = "Invalid Email Address.")]
	public string Email { get; set; }

	[Required]
	[MinLength(4, ErrorMessage = "Password must be at least 4 characters long.")]
	public string Password { get; set; }

    public DateTime CreatedAt { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public Role Role { get; set; }
}

public enum Role
{
    Client,
    Admin
}
