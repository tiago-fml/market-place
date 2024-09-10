using user_service.Models;

namespace user_service.Repositories.Users;

public interface IUserRepository
{
    Task SaveChangesAsync();
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User?> GetUserByUserNameAsync(string username);
    Task<User?> GetUserByEmailAsync(string email);
    Task<List<User>> GetAllUsersAsync();
    void AddUser(User user);
    void DeleteUser(User user); 
}