using backend.Config.DB;

var builder = WebApplication.CreateBuilder(args);

//Microsoft.EntityFramework telepítése!
//Microsoft.EntityFramework.Tools telepítése!
//MySQL.EntityFramework telepítése!

builder.Services.AddDbContext<DatabaseContext>();
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
