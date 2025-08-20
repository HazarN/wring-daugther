
using Microsoft.EntityFrameworkCore;
using dotenv.net;

using api.Data;
using api.Repositories;
using api.Services;
using Scalar.AspNetCore;
using api.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

DotEnv.Load();

// .env Dependencies
var cnn = Environment.GetEnvironmentVariable("DB_URI");
var port = Environment.GetEnvironmentVariable("PORT") ?? "5500";
var secret = Environment.GetEnvironmentVariable("JWT_SECRET");

if (string.IsNullOrEmpty(secret))
    throw new DotEnvException("JWT_SECRET");

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL Database Connection
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(cnn)
);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Repo and Service Mappings
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Authentication Rules
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secret)
            ),
            ValidateIssuerSigningKey = true
        };
    });

// Authorization Rule
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("isAdmin", "True"));
});

builder.WebHost.UseUrls($"http://localhost:{port}");

var app = builder.Build();

// Scalar for API testing
app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
