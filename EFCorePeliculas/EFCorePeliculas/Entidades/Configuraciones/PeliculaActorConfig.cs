using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class PeliculaActorConfig : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            //PeliculaActor LLAVE COMPIESTA en tabla de rompominiento
            builder.HasKey(prop => new { prop.PeliculaId, prop.ActorId });
            builder.Property(prop => prop.Personaje)
                .HasMaxLength(150);

            // v93 Configuracion de relacion N:M en Api Fluente con tabla intermedia creada en el Modelo
            builder.HasOne(pa => pa.Actor)
                .WithMany(a => a.PeliculasActores)
                .HasForeignKey(pa => pa.ActorId);

            builder.HasOne(pe => pe.Pelicula)
                .WithMany(a => a.PeliculasActores)
                .HasForeignKey(pa => pa.PeliculaId);
        }
    }
}
