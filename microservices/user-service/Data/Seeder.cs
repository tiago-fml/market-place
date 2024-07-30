using Microsoft.EntityFrameworkCore;
using user_service.Enums;
using user_service.Models;
using user_service.Utils;

namespace user_service.Data;

public static class Seeder
{
    public static void SeedData(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        using var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
        
        // Look for any users already in the database.
        if (!context.Users.Any())
        {
                
            var adminUsername = configuration["AdminUser:UserName"];
            var adminPassword = configuration["AdminUser:Password"];

            if (adminUsername is null || adminPassword is null)
            {
                return;
            }

            context.Users.AddRange(
                new User
                {
                    Username = adminUsername,
                    HashedPassword = PasswordHasher.HashPassword(adminPassword),
                    Role = Roles.Admin,
                    Email = "",
                    FirstName = "Admin",
                    LastName = "Admin"
                }
            );
        }
            
        context.SaveChanges();
    }
}