using Microsoft.EntityFrameworkCore;
using user_service.Data;
using user_service.Repositories;
using user_service.Services;

namespace user_service;

public static class ProgramExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
    
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }
}