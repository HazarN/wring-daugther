
using Microsoft.EntityFrameworkCore;
using dotenv.net;

using api.Data;
using api.Repositories;
using api.Services;
using Scalar.AspNetCore;

DotEnv.Load();

// .env Dependencies
var cnn = Environment.GetEnvironmentVariable("DB_URI");
var port = Environment.GetEnvironmentVariable("PORT") ?? "5500";

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

builder.WebHost.UseUrls($"http://localhost:{port}");

var app = builder.Build();

// Scalar for API testing
app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
