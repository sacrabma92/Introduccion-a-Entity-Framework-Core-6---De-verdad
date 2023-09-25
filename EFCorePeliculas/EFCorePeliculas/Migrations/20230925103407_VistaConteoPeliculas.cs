using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    /// <inheritdoc />
    public partial class VistaConteoPeliculas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE VIEW [dbo].[PeliculasConteo]
            AS
            SELECT Id, TItulo,
            (SELECT count(*)
            FROM GeneroPelicula
            WHERE PeliculasId = Peliculas.Id) AS CantidadGeneros,
            (SELECT count(distinct CineId)
            FROM PeliculaSalaDeCine
            INNER JOIN SalasDeCines
            ON SalasDeCines.Id = PeliculaSalaDeCine.SalasDeCineId
            WHERE PeliculasId = Peliculas.Id) AS CantidadCines,
            (SELECT count(*)
            FROM PeliculasActores
            WHERE PeliculaId = Peliculas.Id) AS CantidadActores
            FROM Peliculas
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [dbo].[PeliculasConteo]");
        }
    }
}
