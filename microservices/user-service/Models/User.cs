using System.ComponentModel.DataAnnotations;
using user_service.Enums;

namespace user_service.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Role Role { get; set; }
    public DateTime BirthDate { get; set; }
}