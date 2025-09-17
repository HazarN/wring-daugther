using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.RateLimiting;
using Scalar.AspNetCore;
using System.Text;
using System.Threading.RateLimiting;
using dotenv.net;

using api.Data;
using api.Repositories;
using api.Services;
using api.Exceptions;

DotEnv.Load();

// .env Dependencies
var apiPort = Environment.GetEnvironmentVariable("API_PORT");
var mobilePort = Environment.GetEnvironmentVariable("MOBILE_PORT");
var ip = Environment.GetEnvironmentVariable("IP_FO");
var cnn = Environment.GetEnvironmentVariable("DB_URI");
var secret = Environment.GetEnvironmentVariable("JWT_SECRET");

if (
       string.IsNullOrEmpty(secret)
    || string.IsNullOrEmpty(apiPort)
    || string.IsNullOrEmpty(mobilePort)
    || string.IsNullOrEmpty(ip)
)
    throw new DotEnvException("One or more of the .env variables");

var builder = WebApplication.CreateBuilder(args);

// Exposing the backend
builder.WebHost.UseUrls($"http://localhost:{apiPort}", $"http://{ip}:{apiPort}");

// PostgreSQL Database Connection
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(cnn)
);

// CORS Policy Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowExpo",
        policy => policy.WithOrigins(
            $"http://{ip}:{mobilePort}",
            $"http://localhost:{mobilePort}"
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
    );
});

builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Repo and Service Mappings
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Global rate limiter for security
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",

            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 5,
                Window = TimeSpan.FromSeconds(10),
                QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                QueueLimit = 0
            }
        )
    );
});

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
            ValidateIssuerSigningKey = true,
        };
    });

// Authorization Rule
builder.Services
    .AddAuthorizationBuilder()
    .AddPolicy("AdminOnly", policy => policy.RequireClaim("isAdmin", "True"));

var app = builder.Build();

app.UseCors("AllowExpo");

// Scalar for API testing
app.MapOpenApi();
app.MapScalarApiReference();

app.UseRateLimiter();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
