using user_service.Enums;

namespace user_service.DTOs.User;

public class UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Roles Role { get; set; }
    public DateTime? BirthDate { get; set; }
}