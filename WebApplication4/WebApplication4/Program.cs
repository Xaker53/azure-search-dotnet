using Application.CQRS.DeleteUser;
using Application.CQRS.UserCreate;
using Application.Interface.Auth;
using Application.Services;
using Core.Entities.MappingProfiles;
using Core.Interfaces;
using Infrastructure;
using Microsoft.Extensions.Options;
using Persistence.Interactions;
using WebApplication4.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(UserDeleteCQRS).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(UserCreateCQRS).Assembly);
});



builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

builder.Services.AddApiAuthentication(
    builder.Configuration,
    builder.Services.BuildServiceProvider().GetRequiredService<IOptions<JwtOptions>>()
);

builder.Services.AddAutoMapper(typeof(MapperUser).Assembly);

builder.Services.AddScoped<ICreate, UserCreate>();
//builder.Services.AddScoped<UserAddService>();

builder.Services.AddScoped<IRead, UserGetByGmail>();
builder.Services.AddScoped<UserReadService>();


builder.Services.AddScoped<IUpdate, UserUpdate>();
builder.Services.AddScoped<UserUpdateService>();

builder.Services.AddScoped<IDelete, UserDelete>();
//builder.Services.AddScoped<UserDeleteService>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddScoped<UserService>();


builder.Services.AddHttpContextAccessor();


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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
