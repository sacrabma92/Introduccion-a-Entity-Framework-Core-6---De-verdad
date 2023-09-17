using EFCorePeliculas.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFCorePeliculas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //Configurar que en todo el proyecto todo los datetime sean date
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

        // ovverrode OnModelCreating se usa para configurar atributos o
        //API fluente. En este caso se separo para colocarlo en la carpeta Configuraciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Linea que configura el API fluente de la carpeta Configuraciones
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        DbSet<Genero> Generos { get; set; }
        DbSet<Actor> Actores { get; set; }
        DbSet<Cine> Cines { get; set; }
        DbSet<Pelicula> Peliculas { get; set; }
        DbSet<CineOferta> CinesOfertas { get; set; }
        DbSet<SalaDeCine> SalasDeCines { get; set; }
        DbSet<PeliculaActor> PeliculasActores { get; set; }
    }
}
