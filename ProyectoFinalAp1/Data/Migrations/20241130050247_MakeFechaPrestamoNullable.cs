using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAp1.Migrations
{
    /// <inheritdoc />
    public partial class MakeFechaPrestamoNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cobros_prestamos_PrestamosPrestamoId",
                table: "cobros");

            migrationBuilder.DropIndex(
                name: "IX_cobros_PrestamosPrestamoId",
                table: "cobros");

            migrationBuilder.DropColumn(
                name: "PrestamosPrestamoId",
                table: "cobros");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrestamosPrestamoId",
                table: "cobros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cobros_PrestamosPrestamoId",
                table: "cobros",
                column: "PrestamosPrestamoId");

            migrationBuilder.AddForeignKey(
                name: "FK_cobros_prestamos_PrestamosPrestamoId",
                table: "cobros",
                column: "PrestamosPrestamoId",
                principalTable: "prestamos",
                principalColumn: "PrestamoId");
        }
    }
}
