using Microsoft.Extensions.Options;

namespace Origen.Api.Modules.Auth.Bootstrap;

public static class BootstrapExtensions
{
    public static IServiceCollection AddBootstrap(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<AdminBootstrapOptions>(
            configuration.GetSection(
                AdminBootstrapOptions.SectionName));

        services.AddScoped<AdminUserInitializer>();

        return services;
    }
}