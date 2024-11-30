using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAp1.Migrations
{
    /// <inheritdoc />
    public partial class Proyecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cobros_prestamos_PrestamosPrestamoId",
                table: "cobros");

            migrationBuilder.DropForeignKey(
                name: "FK_facturas_pagos_PagoId",
                table: "facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_facturas_pagos_PagosPagoId",
                table: "facturas");

            migrationBuilder.DropTable(
                name: "abonos");

            migrationBuilder.DropTable(
                name: "pagos");

            migrationBuilder.DropIndex(
                name: "IX_facturas_PagoId",
                table: "facturas");

            migrationBuilder.DropIndex(
                name: "IX_facturas_PagosPagoId",
                table: "facturas");

            migrationBuilder.DropIndex(
                name: "IX_cobros_PrestamosPrestamoId",
                table: "cobros");

            migrationBuilder.DropColumn(
                name: "PagoId",
                table: "facturas");

            migrationBuilder.DropColumn(
                name: "PagosPagoId",
                table: "facturas");

            migrationBuilder.DropColumn(
                name: "PrestamosPrestamoId",
                table: "cobros");

            migrationBuilder.CreateTable(
                name: "cobradores",
                columns: table => new
                {
                    CobradorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoCedulaURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cobradores", x => x.CobradorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cobradores");

            migrationBuilder.AddColumn<int>(
                name: "PagoId",
                table: "facturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PagosPagoId",
                table: "facturas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrestamosPrestamoId",
                table: "cobros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "abonos",
                columns: table => new
                {
                    AbonoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    FechaAbono = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoAbono = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abonos", x => x.AbonoId);
                    table.ForeignKey(
                        name: "FK_abonos_facturas_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "facturas",
                        principalColumn: "FacturaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeudorId = table.Column<int>(type: "int", nullable: false),
                    Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PagoPendiente = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagos", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_pagos_deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "deudores",
                        principalColumn: "DeudorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_facturas_PagoId",
                table: "facturas",
                column: "PagoId");

            migrationBuilder.CreateIndex(
                name: "IX_facturas_PagosPagoId",
                table: "facturas",
                column: "PagosPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_cobros_PrestamosPrestamoId",
                table: "cobros",
                column: "PrestamosPrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_abonos_FacturaId",
                table: "abonos",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_DeudorId",
                table: "pagos",
                column: "DeudorId");

            migrationBuilder.AddForeignKey(
                name: "FK_cobros_prestamos_PrestamosPrestamoId",
                table: "cobros",
                column: "PrestamosPrestamoId",
                principalTable: "prestamos",
                principalColumn: "PrestamoId");

            migrationBuilder.AddForeignKey(
                name: "FK_facturas_pagos_PagoId",
                table: "facturas",
                column: "PagoId",
                principalTable: "pagos",
                principalColumn: "PagoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_facturas_pagos_PagosPagoId",
                table: "facturas",
                column: "PagosPagoId",
                principalTable: "pagos",
                principalColumn: "PagoId");
        }
    }
}
