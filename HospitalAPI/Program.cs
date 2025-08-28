using HospitalBusiness.Interfaces;
using HospitalBusiness.Managers;
using HospitalData.Dbcontexts;
using HospitalData.UnitOfWork;
using HospitalData.Interfaces;
using HospitalData.Repositories;
using HospitalAPI.MappingProfile;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<HospitalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Hospitalstring")));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Register Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

// Register Unit of Work and Managers
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPatientManager, PatientManager>();
builder.Services.AddScoped<IUserManager, UserManager>();

// ✅ Register CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Angular dev server
                  .AllowAnyHeader()  // Allow all request headers (like Content-Type, Authorization)
                  .AllowAnyMethod(); // Allow all Post, Put ,Patch, Delete
        });
});

// Register Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hospital API", Version = "v1" });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// ✅ Use CORS before controllers
app.UseCors("AllowAngularApp");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hospital API v1");
    // Optional: makes Swagger available at root (http://localhost:5044/)
    // c.RoutePrefix = string.Empty;
});

app.UseAuthorization();
app.MapControllers();
app.Run();
