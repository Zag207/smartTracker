using Microsoft.Extensions.DependencyInjection;
using SmartTraсker.Data.Abstractions;
using SmartTraсker.Data.Repositories.EF;

namespace SmartTraсker.Data;

public static class ServiceDataExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IRolesRepository, RolesRepository>();
        services.AddScoped<IWorkTaskRepository, WorkTasksRepository>();
        services.AddScoped<ICommentsRepository, CommentsRepository>();
        
        return services;
    }
}