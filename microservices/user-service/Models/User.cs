using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using user_service.Enums;

namespace user_service.Models;

public class User
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] 
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string HashedPassword { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Roles Role { get; set; }
    public DateTime? BirthDate { get; set; }
}