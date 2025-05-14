using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserID { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string Surname { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Role { get; set; }

    [Required]
    public string PasswordHash { get; set; } // Save only hashed passwords
}
