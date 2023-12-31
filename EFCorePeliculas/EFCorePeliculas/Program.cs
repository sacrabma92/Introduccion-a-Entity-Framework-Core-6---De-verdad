using EFCorePeliculas;
using EFCorePeliculas.Servicios;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Quitar problema de desearizacion
builder.Services.AddControllers().AddJsonOptions(opciones =>
opciones.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
{
    // Configuracion para documentar la API en el Swagger
    var archivoXML = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var rutaXML = Path.Combine(AppContext.BaseDirectory, archivoXML);
    c.IncludeXmlComments(rutaXML);
});

// Cadena de conexion y configuracion de NetTopologySuite
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
    {
        opciones.UseSqlServer(connectionString,sqlServer => sqlServer.UseNetTopologySuite());
        // Configuracion del AsNoTracking de forma Global
        opciones.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });

builder.Services.AddScoped<IServicioUsuario,  ServicioUsuario>();

//Configurar el Autommaper
builder.Services.AddAutoMapper(typeof(Program));

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
