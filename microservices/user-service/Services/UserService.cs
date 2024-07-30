using AutoMapper;
using user_service.DTOs.User;
using user_service.Models;
using user_service.Repositories.Users;
using user_service.Utils;

namespace user_service.Services;

public class UserService(IUserRepository userRepo, IMapper mapper) : IUserService
{
    public async Task<UserDto?> GetUserByIdAsync(Guid id)
    {
        var user = await userRepo.GetUserByIdAsync(id);
        return mapper.Map<UserDto>(user);
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var userList = await userRepo.GetAllUsersAsync();
        return mapper.Map<List<UserDto>>(userList);
    }

    public async Task<UserDto> AddUserAsync(UserCreateDto userCreateDto)
    {
        await VerifyUserDetails(userCreateDto);
        
        var user = new User();
        
        mapper.Map(userCreateDto, user);
        
        user.HashedPassword = PasswordHasher.HashPassword(userCreateDto.Password);

        await userRepo.AddUserAsync(user);
        
        return mapper.Map<UserDto>(user);
    }

    public async Task<UserDto?> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto)
    {
        var user = await userRepo.GetUserByIdAsync(id);

        if (user == null)
        {
            return null;
        }

        mapper.Map(userUpdateDto, user);

        await userRepo.UpdateUserAsync(user);

        return mapper.Map<UserDto>(user);
    }

    public async Task<UserDto?> DeleteUserAsync(Guid id)
    {
        var user = await userRepo.GetUserByIdAsync(id);

        if (user == null)
        {
            return null;
        }
        
        await userRepo.DeleteUserAsync(id);

        return mapper.Map<UserDto>(user);
    }
    
    private async Task VerifyUserDetails(UserCreateDto userDetails)
    {
        var user = await userRepo.GetUserByUserNameAsync(userDetails.Username);

        if (user is not null)
        {
            throw new Exception($"The username {userDetails.Username} is already in use.");
        }
        
        user = await userRepo.GetUserByEmailAsync(userDetails.Email);
        
        if (user is not null)
        {
            throw new Exception($"The email {userDetails.Email} is already in use.");
        }

        if (userDetails.Password.Length < 8 || !userDetails.Password.Any(char.IsDigit) || 
            !userDetails.Password.Any(char.IsLetter) || !userDetails.Password.Any(char.IsUpper))
        {
            throw new Exception(@"Password must have at least 8 characters, including at 
                least one number and one letter in upper case");
        }
    }
}