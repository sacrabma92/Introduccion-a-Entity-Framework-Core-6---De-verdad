using EFCorePeliculas.Entidades.Conversiones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class SalaDeCineConfig : IEntityTypeConfiguration<SalaDeCine>
    {
        public void Configure(EntityTypeBuilder<SalaDeCine> builder)
        {
            // SalaDeCine
            builder.Property(prop => prop.Precio)
                .HasPrecision(precision: 9, scale: 2);
            builder.Property(prop => prop.TipoSalaDeCine)
                .HasDefaultValue(TipoSalaDeCine.DosDimensiones)
                //v78 uso de HasConversion
                .HasConversion<string>();

            // v79 convertir de moneda a string y viceversa
            builder.Property(prop => prop.Moneda)
                .HasConversion<MonedaASimboloConverter>();
        }
    }
}
