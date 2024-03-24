using user_service.Enums;

namespace user_service.DTOs.User;

public class UserCreateDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Role Role { get; set; }
    public DateTime BirthDate { get; set; }
}