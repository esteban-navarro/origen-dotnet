using Microsoft.EntityFrameworkCore;
using Origen.Api.Data;
using Origen.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// CORS
builder.Services.AddCorsConfiguration(builder.Configuration);

// Swagger
builder.Services.AddSwaggerDocumentation();

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseHttpsRedirection();

// CORS
app.UseCors(CorsExtensions.DefaultPolicy);

// Authentication / Authorization
app.UseAuthorization();

// Endpoints
app.MapControllers();

app.Run();