﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entidades
{
    public class CineOfertaConfig : IEntityTypeConfiguration<CineOferta>
    {
        public void Configure(EntityTypeBuilder<CineOferta> builder)
        {
            //Entidad CineOferta
            builder.Property(prop => prop.PorcentajeDescuento)
                         .HasPrecision(precision: 5, scale: 2);
        }
    }
}
