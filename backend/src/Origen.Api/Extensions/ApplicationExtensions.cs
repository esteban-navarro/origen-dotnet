using Origen.Api.Modules.Auth.Bootstrap;

namespace Origen.Api.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddCorsConfiguration(configuration);
        services.AddSwaggerDocumentation();
        services.AddSecurityServices(configuration);
        services.AddRepositories();
        services.AddApplicationServices();
        services.AddBootstrap(configuration);

        return services;
    }
}