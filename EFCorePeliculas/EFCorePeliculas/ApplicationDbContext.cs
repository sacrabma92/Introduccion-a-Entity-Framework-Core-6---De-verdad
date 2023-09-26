using EFCorePeliculas.Entidades;
using EFCorePeliculas.Entidades.Seeding;
using EFCorePeliculas.Entidades.SinLLaves;
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
            SeedingModuloConsulta.Seed(modelBuilder);
            //SeedingPersonaMensaje.Seed(modelBuilder);

            //v80 Entidad sin llaves
            modelBuilder.Entity<CineSinUbicacion>().HasNoKey()
                .ToSqlQuery("Select Id, Nombre FROM Cines").ToView(null);

            modelBuilder.Entity<PeliculaConConteos>().HasNoKey().ToView("PeliculasConteo"); 
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<CineOferta> CinesOfertas { get; set; }
        public DbSet<SalaDeCine> SalasDeCines { get; set; }
        public DbSet<PeliculaActor> PeliculasActores { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
    }
}
