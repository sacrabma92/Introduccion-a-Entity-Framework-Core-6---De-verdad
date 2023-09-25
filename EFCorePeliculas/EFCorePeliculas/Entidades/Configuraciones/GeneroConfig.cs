using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            // Genero
            builder.HasKey(prop => prop.Identificador);
            builder.Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();

            // v70 no muesta los que esten desactivados
            builder.HasQueryFilter(g => !g.EstaBorrado);

            // v76 Crear un indice en la tabla genero
            //builder.HasIndex(prop => prop.Nombre).IsUnique();

            // v77 Indice con filtro
            builder.HasIndex(prop => prop.Nombre).IsUnique().HasFilter("EstaBorrado = 'false'");
        }
    }
}
