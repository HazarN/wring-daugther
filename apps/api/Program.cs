
using Microsoft.EntityFrameworkCore;
using dotenv.net;

using api.Data;
using api.Repositories;
using api.Services;

DotEnv.Load();

var cnn = Environment.GetEnvironmentVariable("DB_URI");

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL Database Connection
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(cnn)
);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
// Repo and Service Mappings
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// SwaggerUI for end-point testing
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
