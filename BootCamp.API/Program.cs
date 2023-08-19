using BootCamp.API.Configurations;
using BootCamp.BusinessLogic.Services.Implementations;
using BootCamp.BusinessLogic.Services.Interfaces;
using BootCamp.Data.Context;
using BootCamp.Data.Entities;
using BootCamp.Data.Repository.Implementation;
using BootCamp.Data.Repository.Interface;
using BootCamp.Data.Seed;
using Microsoft.AspNetCore.Identity;
using static BootCamp.BusinessLogic.Services.Implementations.TestScoresService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddDbConfig(builder.Configuration);
builder.Services.AddServices();

builder.Services.AddScoped<ITestScoreRepository, TestScoreRepository>();
builder.Services.AddScoped<ITestScoresService, TestScoreService>();

builder.Services.AddScoped<IGetUserById, GetUserByIdRepo>();
builder.Services.AddScoped<IGetUserByIdService, GetUserByIdService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// seeding method here
//using var scope = app.Services.CreateScope();
//var services = scope.ServiceProvider;
//var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
//var userManager = services.GetRequiredService<UserManager<Trainee>>();
//var dbContext = services.GetRequiredService<MyAppContext>();
//await Seeder.Seed(roleManager, userManager, dbContext);

app.Run();
