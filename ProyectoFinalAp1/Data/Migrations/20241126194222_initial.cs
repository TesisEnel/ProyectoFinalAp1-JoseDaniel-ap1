using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAp1.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CobrosCobroId",
                table: "facturas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_facturas_CobrosCobroId",
                table: "facturas",
                column: "CobrosCobroId");

            migrationBuilder.AddForeignKey(
                name: "FK_facturas_cobros_CobrosCobroId",
                table: "facturas",
                column: "CobrosCobroId",
                principalTable: "cobros",
                principalColumn: "CobroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_facturas_cobros_CobrosCobroId",
                table: "facturas");

            migrationBuilder.DropIndex(
                name: "IX_facturas_CobrosCobroId",
                table: "facturas");

            migrationBuilder.DropColumn(
                name: "CobrosCobroId",
                table: "facturas");
        }
    }
}
