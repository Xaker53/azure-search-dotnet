using Core.Interfaces;
using Persistence.Interactions;
using Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICreate, UserCreate>();
builder.Services.AddScoped<UserAddService>();

builder.Services.AddScoped<IRead, UserGetByGmail>();
builder.Services.AddScoped<UserReadService>();


builder.Services.AddScoped<IUpdate, UserUpdate>();
builder.Services.AddScoped<UserUpdateService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();


}
app.UseCors(
        options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
