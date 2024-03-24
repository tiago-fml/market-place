using user_service.Models;

namespace user_service.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(Guid userId);
    Task<User> GetUserByUserNameAsync(string username);
    Task<User> GetUserByEmailAsync(string email);
    Task<List<User>> GetAllUsersAsync();
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(Guid userId); 
}