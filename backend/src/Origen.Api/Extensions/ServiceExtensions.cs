using Origen.Api.Modules.Auth.Services;
using Origen.Api.Modules.Users.Services;

namespace Origen.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}