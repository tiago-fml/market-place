﻿using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using user_service.Repositories.Users;
using user_service.Services;

namespace user_service;

public static class ProgramExtensions
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Users Service", Version = "v1" });

            // Add security definition
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                In = ParameterLocation.Header,
                Description = "Enter 'Bearer' followed by a space and then your JWT token"
            });

            // Add security requirement
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }
    public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtKey = configuration["Jwt:Key"];

        if (jwtKey is null)
        {
            throw new Exception("Invalid Jwt Key in AppSettings");
        }
        
        var key = Encoding.ASCII.GetBytes(jwtKey);

        services.AddAuthentication()
        .AddJwtBearer(jwtOptions =>
        {
            jwtOptions.RequireHttpsMetadata = false;
            jwtOptions.SaveToken = true;
            jwtOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }
}