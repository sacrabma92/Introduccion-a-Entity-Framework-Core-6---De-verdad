using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class PeliculaSalaDeCineConfig : IEntityTypeConfiguration<PeliculaSalaDeCine>
    {
        public void Configure(EntityTypeBuilder<PeliculaSalaDeCine> builder)
        {
            //Entidad PeliculaSalaDeCine
            builder.HasKey(prop =>
              new { prop.PeliculaId, prop.SalaDeCineId });
        }
    }
}
