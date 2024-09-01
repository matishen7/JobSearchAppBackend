using JobSearchAppBackend.Data;
using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.MapperProfiles;
using JobSearchAppBackend.Repositories;
using JobSearchAppBackend.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
//builder.Services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
//builder.Services.AddScoped<IJobApplicationService, JobApplicationService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
