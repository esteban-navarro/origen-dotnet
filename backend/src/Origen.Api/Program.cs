using Microsoft.EntityFrameworkCore;
using Origen.Api.Data;
using Origen.Api.Extensions;
using Origen.Api.Modules.Auth.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Application
builder.Services.AddApplicationConfiguration(builder.Configuration);

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IApplicationDbContext>(
    provider => provider.GetRequiredService<ApplicationDbContext>());

var app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    AdminUserInitializer initializer =
        scope.ServiceProvider
            .GetRequiredService<AdminUserInitializer>();

    await initializer.InitializeAsync();
}

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseHttpsRedirection();

// CORS
app.UseCors(CorsExtensions.DefaultPolicy);

// Authentication / Authorization
app.UseAuthentication();
app.UseAuthorization();

// Endpoints
app.MapControllers();

app.Run();