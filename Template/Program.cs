using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.Interfaces; // Asegúrate de incluir el namespace de IPresentationService
using Application.UseCase;
using Application.Interfaces.Commands;
using Application.Interfaces.Querys;
using Infrastructure.Querys;
using Infrastructure.Commands;
using Application.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IPresentationService, PresentationService>();
builder.Services.AddScoped<IPresentationQuery, PresentationQuery>();
builder.Services.AddScoped<IPresentationCommands, PresentationCommand>();

builder.Services.AddScoped<ISlideService, SlideService>();
builder.Services.AddScoped<ISlideQuery, SlideQuery>();
builder.Services.AddScoped<ISlideCommand, SlideCommand>();

builder.Services.AddScoped<IAskService, AskService>();
builder.Services.AddScoped<IAskQuery, AskQuery>();
builder.Services.AddScoped<IAskCommands, AskCommand>();

builder.Services.AddScoped<IOptionService, OptionService>();
builder.Services.AddScoped<IOptionQuery, OptionQuery>();
builder.Services.AddScoped<IOptionCommands, OptionCommand>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ServiceContext>(options => options.UseSqlServer(connectionString));


// Configuración de CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5500",
                              "http://127.0.0.1:5500",
                              "http://127.0.0.1:5501",
                              "https://127.0.0.1:5500",
                              "http://127.0.0.1:3000",
                              "https://slidex-front-end.vercel.app")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials(); // Si usás credenciales
                      });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();


// Routing antes de auth
app.UseRouting();

// CORS antes de auth si se usan cookies
app.UseCors(MyAllowSpecificOrigins);

// Autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

// Usar endpoints de controladores
app.MapControllers();

app.Run();
