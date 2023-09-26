using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class CineConfig : IEntityTypeConfiguration<Cine>
    {
        public void Configure(EntityTypeBuilder<Cine> builder)
        {
            //Cines
            builder.Property(prop => prop.Nombre)
                .HasMaxLength(150)
                .IsRequired();

            // v91 configuracion de relacion 1:1
            builder.HasOne(c => c.CineOferta)
                .WithOne()
                .HasForeignKey<CineOferta>(co => co.CineId);

            // v92 configuracion de relacion 1:N
            builder.HasMany(c => c.SalaDeCine)
                .WithOne(s => s.Cine)
                .HasForeignKey(s => s.CineId)
                //v95 No poder borrar un cine si este tiene valores en la tabla SalasDeCine
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
