using user_service.Enums;

namespace user_service.DTOs.User;

public class UserUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}