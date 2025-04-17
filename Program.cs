using auth_api.Infrastructure;
using auth_api.Model;
using auth_api.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

//key for the tokens
Configuration.Initialize(builder.Configuration);
// Service registration
builder.Services.AddScoped<TokenService>();  // TokenService registration
builder.Services.AddTransient<IUserRepository, UserRepository>();  // User repository registration

builder.Services.AddControllers();

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Authentication configuration (using HTTPS for the authority URL)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // Authority URL using HTTPS
        options.Authority = "https://localhost:5000";  // Replace with the URL of your authentication server
        options.Audience = "api1";  // Replace with the audience of your API

        // If you are using a provider that requires HTTPS
        options.RequireHttpsMetadata = true;
    });

var app = builder.Build();

// Swagger configuration (development environment only)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Activate Swagger
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1"));  // Configure the Swagger endpoint
}

// Make sure that the Swagger middleware is called before authentication and authorization
app.UseHttpsRedirection();

// Authentication middleware
app.UseAuthentication();  // Authentication middleware (JWT)

app.UseAuthorization();  // Authorization middleware

app.MapControllers();  // Map the controllers

app.Run();
