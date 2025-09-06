
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

// Scalar for API testing
app.MapOpenApi();
app.MapScalarApiReference();

app.UseRateLimiter();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

builder.WebHost.UseUrls($"http://localhost:{port}");
app.Run();
