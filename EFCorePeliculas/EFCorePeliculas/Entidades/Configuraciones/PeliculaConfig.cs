using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            // Peliculas
            builder.Property(prop => prop.Titulo)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(prop => prop.PosterURL)
                .HasMaxLength(500)
                .IsUnicode(false);

            // v94 configuracion de relacion cuando la tabla intermedia se crea por entity.
            // relacion N:M
            builder.HasMany(g => g.Generos)
                .WithMany(p => p.Peliculas);
                // Cambiar el nombre de la tabla intermedia
                //.UsingEntity(j => 
                //    j.ToTable("GenerosPeliculas"));
        }
    }
}
