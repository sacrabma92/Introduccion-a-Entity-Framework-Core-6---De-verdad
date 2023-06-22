﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            //Entidad Pelicula
            builder.Property(prop => prop.Titulo)
                         .HasMaxLength(250)
                         .IsRequired();
            builder.Property(prop => prop.PosterURL)
                         .HasMaxLength(500);
        }
    }
}
