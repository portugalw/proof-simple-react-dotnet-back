using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using vendsys_api.Api;
using vendsys_api.Application.Parsers;
using vendsys_api.Application.Services;
using vendsys_api.Domain.Interfaces;
using vendsys_api.Dto;
using vendsys_api.Infrastructure.Auth;
using vendsys_api.Infrastructure.Data;
using vendsys_api.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



// EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default"),
        sqlOptions =>
        {
            // Enables resilient connections (recommended even for LocalDB)
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 3,
                maxRetryDelay: TimeSpan.FromSeconds(5),
                errorNumbersToAdd: null
            );
        }
    ));

// Auth
builder.Services.AddScoped<ICredentialProvider, HardcodedCredentialProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();

// DEX
builder.Services.AddScoped<IDexRepository, DexRepository>();
builder.Services.AddScoped<IDexLaneRepository, DexLaneRepository>();
builder.Services.AddScoped<IDexParser, DexParser>();
builder.Services.AddScoped<IUploadDexService, UploadDexService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy
            .SetIsOriginAllowed(origin =>
            {
                if (string.IsNullOrEmpty(origin))
                    return false;

                var uri = new Uri(origin);
                return uri.Host.Equals("localhost", StringComparison.OrdinalIgnoreCase);
            })
            .AllowAnyHeader()
            .AllowAnyMethod();
        // ❌ DO NOT use AllowCredentials with wildcard origins
    });
});




var app = builder.Build();

app.UseCors("AllowLocalhost");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



// Middleware
app.UseMiddleware<BasicAuthMiddleware>();

// Endpoints
app.MapAuthEndpoints();
app.MapDexEndpoints();

app.UseAuthorization();

app.MapControllers();

app.Run();
