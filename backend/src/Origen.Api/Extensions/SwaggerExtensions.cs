using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Origen.Api.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "ORIGEN API",
                Version = "v1.0.0",
                Description = "Modern Enterprise REST API built with ASP.NET Core 9.",
                License = new OpenApiLicense
                {
                    Name = "MIT License",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }
            });
        });

        return services;
    }

    public static WebApplication UseSwaggerDocumentation(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ORIGEN API v1.0.0");
                options.RoutePrefix = "swagger";
            });

            return app;
        }

        return app;
    }
}