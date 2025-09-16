using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Подключаем DbContext
builder.Services.AddDbContext<UserdbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserConnect")));

var app = builder.Build();

app.Run();
