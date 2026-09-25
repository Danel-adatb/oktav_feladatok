using backend.Config.DB;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DatabaseContext") ?? throw new InvalidOperationException("Connection string 'DatabaseContext' not found.");

//Microsoft.EntityFramework telepítése!
//Microsoft.EntityFramework.Tools telepítése!
//MySQL.EntityFramework telepítése!
//Scalar telepítése ls config:
/**
 "https": {
  "commandName": "Project",
  "dotnetRunMessages": true,
  "launchBrowser": true,
  "launchUrl": "scalar/v1",
  "applicationUrl": "https://localhost:7161;http://localhost:5255",
  "environmentVariables": {
    "ASPNETCORE_ENVIRONMENT": "Development"
  }
}
 */

 //Migration: Add-Migration viragbolt
 //Update: Update-Database

builder.Services.AddDbContext<DatabaseContext>();
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //Ezt hozzáadni
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
