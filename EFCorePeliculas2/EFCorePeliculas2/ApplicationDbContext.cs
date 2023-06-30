using EFCorePeliculas2.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas2
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
            modelBuilder.Entity<Genero>().Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();

            //Entidad Actor
            modelBuilder.Entity<Actor>().Property(prop => prop.Nombre)
                .HasMaxLength(150);
            modelBuilder.Entity<Actor>().Property(prop => prop.FechaNacimiento)
                .HasColumnName("date");

            //Entidad Cine
            modelBuilder.Entity<Cine>().Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();
            modelBuilder.Entity<Cine>().Property(prop => prop.Precio)
                .HasPrecision(precision: 9, scale: 2);

            //Entidad Pelicula
            modelBuilder.Entity<Pelicula>().Property(prop => prop.Titulo)
                .HasMaxLength(250)
                .IsRequired();
            modelBuilder.Entity<Pelicula>().Property(prop => prop.FechaEstreno)
                .HasColumnType("date");
            modelBuilder.Entity<Pelicula>().Property(prop => prop.PosterURL)
                .HasMaxLength(500);

        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
    }
}
