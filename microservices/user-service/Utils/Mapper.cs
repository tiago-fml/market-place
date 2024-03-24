using AutoMapper;
using user_service.DTOs.User;
using user_service.Models;

namespace user_service.Utils;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserCreateDto, User>();
        CreateMap<UserUpdateDto, User>();
    }
}