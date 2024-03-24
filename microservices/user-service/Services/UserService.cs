using AutoMapper;
using user_service.DTOs.User;
using user_service.Repositories;

namespace user_service.Services;

public class UserService : IUserService
{
    private IUserRepository _userRepository;
    private IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> GetUserByIdAsync(Guid id)
    {
        var user = _userRepository.GetUserByIdAsync(id);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var userList = await _userRepository.GetAllUsersAsync();
        return _mapper.Map<List<UserDto>>(userList);
    }

    public async Task<UserDto> AddUserAsync(UserCreateDto userCreateDto)
    {
        var user = await _userRepository.GetUserByUserNameAsync(userCreateDto.Username);

        if (user is not null)
        {
            throw new Exception($"The username {userCreateDto.Username} is already in use.");
        }
        
        user = await _userRepository.GetUserByEmailAsync(userCreateDto.Email);
        
        if (user is not null)
        {
            throw new Exception($"The email {userCreateDto.Email} is already in use.");
        }

        _mapper.Map(userCreateDto, user);

        await _userRepository.AddUserAsync(user);
        
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            throw new Exception($"User with id: {id} was not found.");
        }

        _mapper.Map(userUpdateDto, user);

        await _userRepository.UpdateUserAsync(user);

        return _mapper.Map<UserDto>(user);
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            throw new Exception($"User with id: {id} was not found.");
        }
        
        await _userRepository.DeleteUserAsync(id);
    }
    
}