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
                Title = "Origen API",
                Version = "v1",
                Description = "Backend API for the Origen Full Stack application."
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
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Origen API v1");
                options.RoutePrefix = "swagger";
            });

            return app;
        }

        return app;
    }
}