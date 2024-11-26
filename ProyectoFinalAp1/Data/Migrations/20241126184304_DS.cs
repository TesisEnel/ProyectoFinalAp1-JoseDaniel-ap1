using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAp1.Migrations
{
    /// <inheritdoc />
    public partial class DS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cobros_prestamos_PrestamoId",
                table: "cobros");

            migrationBuilder.DropForeignKey(
                name: "FK_cobros_prestamos_PrestamosId",
                table: "cobros");

            migrationBuilder.DropForeignKey(
                name: "FK_facturas_pagos_PagoId",
                table: "facturas");

            migrationBuilder.DropIndex(
                name: "IX_cobros_PrestamosId",
                table: "cobros");

            migrationBuilder.DropColumn(
                name: "PrestamosId",
                table: "cobros");

            migrationBuilder.AddForeignKey(
                name: "FK_cobros_prestamos_PrestamoId",
                table: "cobros",
                column: "PrestamoId",
                principalTable: "prestamos",
                principalColumn: "PrestamosId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_facturas_pagos_PagoId",
                table: "facturas",
                column: "PagoId",
                principalTable: "pagos",
                principalColumn: "PagoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cobros_prestamos_PrestamoId",
                table: "cobros");

            migrationBuilder.DropForeignKey(
                name: "FK_facturas_pagos_PagoId",
                table: "facturas");

            migrationBuilder.AddColumn<int>(
                name: "PrestamosId",
                table: "cobros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cobros_PrestamosId",
                table: "cobros",
                column: "PrestamosId");

            migrationBuilder.AddForeignKey(
                name: "FK_cobros_prestamos_PrestamoId",
                table: "cobros",
                column: "PrestamoId",
                principalTable: "prestamos",
                principalColumn: "PrestamosId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_cobros_prestamos_PrestamosId",
                table: "cobros",
                column: "PrestamosId",
                principalTable: "prestamos",
                principalColumn: "PrestamosId");

            migrationBuilder.AddForeignKey(
                name: "FK_facturas_pagos_PagoId",
                table: "facturas",
                column: "PagoId",
                principalTable: "pagos",
                principalColumn: "PagoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
