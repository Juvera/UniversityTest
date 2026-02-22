using AchillesTest.Application.Interfaces;
using AchillesTest.Application.Service;
using AchillesTest.Infrastructure.Data.Contexts;
using AchillesTest.WebApi.Middlewares;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("OpenPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Obtenemos el nombre del ensamblado donde se encuentran las migraciones de Entity Framework Core
var migrationsAssembly = typeof(UniversidadDbContext).Assembly.GetName().Name;
// Registro del contexto de la base de datos, utilizando SQL Server como proveedor
builder.Services.AddDbContext<UniversidadDbContext>(options =>
    options.UseSqlServer(connectionString, x => x.MigrationsAssembly(migrationsAssembly)));

// Registramos los servicios de la aplicación
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IDistritoService, DistritoService>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IProvinciaService, ProvinciaService>();

// Registramos los servicios de controladores, exploración de endpoints y generación de Swagger para la documentación de la API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuramos CORS para permitir solicitudes desde el Angular
app.UseCors("OpenPolicy");

// Agregamos el middleware de manejo de excepciones personalizado para capturar y manejar errores de manera centralizada
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();