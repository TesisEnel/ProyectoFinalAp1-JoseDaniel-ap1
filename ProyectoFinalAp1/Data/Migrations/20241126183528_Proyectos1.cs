using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAp1.Migrations
{
    /// <inheritdoc />
    public partial class Proyectos1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_facturas_pagos_PagoId",
                table: "facturas");

            migrationBuilder.AddForeignKey(
                name: "FK_facturas_pagos_PagoId",
                table: "facturas",
                column: "PagoId",
                principalTable: "pagos",
                principalColumn: "PagoId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_facturas_pagos_PagoId",
                table: "facturas");

            migrationBuilder.AddForeignKey(
                name: "FK_facturas_pagos_PagoId",
                table: "facturas",
                column: "PagoId",
                principalTable: "pagos",
                principalColumn: "PagoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
