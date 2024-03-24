using user_service.DTOs.User;

namespace user_service.Services;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(Guid userId);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> AddUserAsync(UserCreateDto user);
    Task<UserDto> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto);
    Task DeleteUserAsync(Guid userId);
}