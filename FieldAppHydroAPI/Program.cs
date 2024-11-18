using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StationDataApi.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

// Configure Configuration
IConfiguration configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

// Configure DbContext with connection string
builder.Services.AddDbContext<StationDataContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<GuelphNetworkContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("GuelphConnection")));

builder.Services.AddDbContext<StationDetailsContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("StagingDBConnection")));

// Configure CORS - Use a named policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

// Use the named CORS policy defined above
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// Map controllers after middleware
app.MapControllers();

app.Run();
