using AutoMapper;
using user_service.DTOs.User;
using user_service.Models;
using user_service.Repositories;
using user_service.Repositories.Users;

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
        var user = await userRepo.GetUserByUserNameAsync(userCreateDto.Username);

        if (user is not null)
        {
            throw new Exception($"The username {userCreateDto.Username} is already in use.");
        }
        
        user = await userRepo.GetUserByEmailAsync(userCreateDto.Email);
        
        if (user is not null)
        {
            throw new Exception($"The email {userCreateDto.Email} is already in use.");
        }

        user = new User();
        
        mapper.Map(userCreateDto, user);

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
    
}