using HospitalBusiness.Interfaces;
using HospitalBusiness.Managers;
using HospitalData.Dbcontexts;
using HospitalData.Interfaces;
using HospitalData.Repositories;
using HospitalData.UnitOfWork;
using HospitalAPI.MappingProfile;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<HospitalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("hospitalString")));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Register DI
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPatientManager, PatientManager>();

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
