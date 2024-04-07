using Microsoft.EntityFrameworkCore;
using NostaleLauncher.API.Services;
using NostaleLauncher.Domain.Interfaces;
using NostaleLauncher.Infrastructure.Data;
using NostaleLauncher.Infrastructure.Repositories;
using NostaleLauncher.Domain.Entities;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
