using user_service.DTOs.Role;
using user_service.DTOs.User;
using user_service.Enums;

namespace user_service.Services;

public interface IUserService
{
    Task<UserDto?> GetUserByIdAsync(Guid userId);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> AddUserAsync(UserCreateDto user, Roles role);
    Task<UserDto?> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto);
    Task<UserDto?> DeleteUserAsync(Guid userId);
    List<RoleDto> GetAllUserRoles();
}