using EFCorePeliculas.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Entidad Genero
            modelBuilder.Entity<Genero>().HasKey(prop => prop.Identificador);
            modelBuilder.Entity<Genero>().Property(prop => prop.Nombre)
                        .HasMaxLength(150)
                        .IsRequired();

            //Entidad Actor
            modelBuilder.Entity<Actor>().Property(prop => prop.Nombre)
                         .HasMaxLength(150)
                         .IsRequired();
            modelBuilder.Entity<Actor>().Property(prop => prop.FechaNacimiento)
                        .HasColumnType("date");

            //Entidad Cine
            modelBuilder.Entity<Cine>().Property(prop => prop.Nombre)
                        .HasMaxLength(150)
                        .IsRequired();

            //Entidad SalaDeCine
            modelBuilder.Entity<SalaDeCine>().Property(prop => prop.Precio)
                        .HasPrecision(precision: 9, scale: 2);
            modelBuilder.Entity<SalaDeCine>().Property(prop => prop.TipoSalaDeCine)
                        .HasDefaultValue(TipoSalaDeCine.DosDimensiones);

            //Entidad Pelicula
            modelBuilder.Entity<Pelicula>().Property(prop => prop.Titulo)
                         .HasMaxLength(250)
                         .IsRequired();
            modelBuilder.Entity<Pelicula>().Property(prop => prop.FechaEstreno)
                        .HasColumnType("date");
            modelBuilder.Entity<Pelicula>().Property(prop => prop.PosterURL)
                         .HasMaxLength(500);

            //Entidad CineOferta
            modelBuilder.Entity<CineOferta>().Property(prop => prop.PorcentajeDescuento)
                         .HasPrecision(precision: 5, scale: 2);
            modelBuilder.Entity<CineOferta>().Property(prop => prop.FechaInicio)
                        .HasColumnType("date");
            modelBuilder.Entity<CineOferta>().Property(prop => prop.FechaFin)
                        .HasColumnType("date");

        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<CineOferta> CinesOfertas { get; set; }
        public DbSet<SalaDeCine> SalasDeCine { get; set; }
        public DbSet<Pelicula> Peliculas{ get; set; }
    }
}
