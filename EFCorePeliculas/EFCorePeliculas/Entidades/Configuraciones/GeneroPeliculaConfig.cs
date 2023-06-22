using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class GeneroPeliculaConfig : IEntityTypeConfiguration<GeneroPelicula>
    {
        public void Configure(EntityTypeBuilder<GeneroPelicula> builder)
        {
            //Entidad GeneroPelicula
            builder.HasKey(prop =>
                         new { prop.GeneroId, prop.PeliculaId });
        }
    }
}
