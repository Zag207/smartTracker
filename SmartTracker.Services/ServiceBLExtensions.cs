using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SmartTracker.Services.Abstractions;
using SmartTracker.Services.AuthExtensions;
using SmartTracker.Services.Services;
using SmartTraсker.Data.Abstractions;

namespace SmartTracker.Services;

public static class ServiceBLExtensions
{
    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var authSettings = configuration.GetSection("AuthSettings").Get<AuthSettings>();
        
        services.Configure<AuthSettings>(
            configuration.GetSection("AuthSettings"));

        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IAuthService, JwtAuthService>();
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authSettings.Issuer,
                    
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(authSettings.Secretkey))
                };
            });
        
        return services;
    }
    
    public static IServiceCollection AddServices(
        this IServiceCollection services
        )
    {
        services.AddScoped<RolesNames>(provider =>
        {
            var instance = new RolesNames(
                provider.GetRequiredService<IRolesRepository>()
            );

            instance.InitRoles().Wait();
            return instance;
        });

        services.AddScoped<UserService>();
        services.AddScoped<WorkTaskService>();
        services.AddScoped<CommentsService>();
        
        return services;
    }
}