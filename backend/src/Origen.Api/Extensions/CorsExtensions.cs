namespace Origen.Api.Extensions;

public static class CorsExtensions
{
    public const string DefaultPolicy = "DefaultPolicy";

    public static IServiceCollection AddCorsConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var allowedOrigins = configuration
            .GetSection("Cors:AllowedOrigins")
            .Get<string[]>();

        if (allowedOrigins is null || allowedOrigins.Length == 0)
        {
            throw new InvalidOperationException(
                "No CORS origins have been configured.");
        }

        services.AddCors(options =>
        {
            options.AddPolicy(DefaultPolicy, policy =>
            {
                policy
                    .WithOrigins(allowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        return services;
    }
}