namespace Origen.Api.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddCorsConfiguration(configuration);
        services.AddSwaggerDocumentation();

        return services;
    }
}