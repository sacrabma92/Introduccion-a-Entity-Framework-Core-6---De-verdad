using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    /// <inheritdoc />
    public partial class NoPodemosBorrarCinesConSalasDeCine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalasDeCines_Cines_CineId",
                table: "SalasDeCines");

            migrationBuilder.AddForeignKey(
                name: "FK_SalasDeCines_Cines_CineId",
                table: "SalasDeCines",
                column: "CineId",
                principalTable: "Cines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalasDeCines_Cines_CineId",
                table: "SalasDeCines");

            migrationBuilder.AddForeignKey(
                name: "FK_SalasDeCines_Cines_CineId",
                table: "SalasDeCines",
                column: "CineId",
                principalTable: "Cines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
