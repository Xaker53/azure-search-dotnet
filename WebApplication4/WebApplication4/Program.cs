using System.Reflection;
using Application;
using Application.CQRS.DeleteUser;
using Application.CQRS.UserCreate;
using Application.Interface;
using Application.Interface.Auth;
using Application.Services;
using Application.Services.Interface;
using Core.Entities.MappingProfiles;
using Core.Enums;
using Core.Interface;
using Core.Interfaces;
using Infrastructure;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

//using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.Interactions;
using Persistence.Models;
using WebApplication4;
using WebApplication4.Extensions;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;
using Application.Services.GeneratePasswordSalt;
using Application.Validation;

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
builder.Services.Configure<Persistence.AuthorizationOptions>(builder.Configuration.GetSection(nameof(Persistence.AuthorizationOptions)));
builder.Services.Configure<AzureOptions>(builder.Configuration.GetSection(nameof(AzureOptions)));


builder.Services.AddApiAuthentication(
    builder.Configuration,
    builder.Services.BuildServiceProvider().GetRequiredService<IOptions<JwtOptions>>()
);

//builder.Services.AddDbContext<UserdbContext>((sp, options) =>
//{
//    var cfg = sp.GetRequiredService<IConfiguration>();
//    var cs = cfg.GetConnectionString("DefaultConnection");

//    options.UseSqlServer(cs);
//});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ReadPolicy", policy =>
        policy.AddRequirements(new PermissionRequirement(new[] { Permission.Read })));
});


builder.Services.AddAutoMapper(typeof(MapperUser).Assembly);

builder.Services.AddDbContext<DbContext, UserdbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ICreate, UserCreate>();
//builder.Services.AddScoped<UserAddService>();

builder.Services.AddScoped<IRead, UserGetByGmail>();
builder.Services.AddScoped<UserReadService>();


builder.Services.AddScoped<IUpdate, UserUpdate>();
builder.Services.AddScoped<UserUpdateService>();

builder.Services.AddScoped<IDelete, UserDelete>();
//builder.Services.AddScoped<UserDeleteService>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordVerify, PasswordVerify>();

builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();


builder.Services.AddScoped<IUserGetPermissionsRepository, GetUserIDPermissions>();
builder.Services.AddScoped<IPermissionService, PermissionsService>();


builder.Services.AddSingleton<IStrategyMarker, CreateSalt>();
builder.Services.AddSingleton<IStrategyMarker, PasswordHasher>();
//builder.Services.AddSingleton<ISalt, CreateSalt>();

builder.Services.AddScoped<IGenerateSaltAndHash, GenerateSaltAndHash>();

builder.Services.AddSingleton<ConnectAzure>();
builder.Services.AddSingleton<IUserDtoValidator, UserDtoValidator>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    var assembly = Assembly.GetExecutingAssembly();

    containerBuilder.RegisterAssemblyTypes(assembly)
        .AssignableTo<IStrategyMarker>()
        .AsImplementedInterfaces()
        .SingleInstance();

    containerBuilder.RegisterType<SaltAndHashFactory>()
        .As<ISaltAndHashFactory>()
        .SingleInstance();
});

//builder.Services.AddSingleton<ISaltAndHashFactory, SaltAndHashFactory>();
builder.Services.AddHttpContextAccessor();

//builder.Services.AddAuthorization(options=>
//{
//    options.AddPolicy("UserPolicy", policy =>
//    {
//        policy.Requirements.Add();
//    });
//});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});



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
