using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositorys.Repos;
using TurnosLibreria.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TurnosContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS",
        policy =>
        {
            policy.AllowAnyOrigin()  // Permite cualquier origen (puedes restringir esto más tarde)
                  .AllowAnyMethod()  // Permite cualquier método (GET, POST, PUT, DELETE, etc.)
                  .AllowAnyHeader(); // Permite cualquier encabezado
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<TurnoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
