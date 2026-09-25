using Scalar.AspNetCore;
using viragbolt.Config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var conneciton = builder.Configuration.GetConnectionString("DatabaseContext") ?? throw new InvalidOperationException("Connextion string 'DatabaseContext' not found.");

builder.Services.AddDbContext<DatabaseContext>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
