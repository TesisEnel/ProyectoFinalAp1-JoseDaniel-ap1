using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAp1.Migrations
{
    /// <inheritdoc />
    public partial class ProyectoFinales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "deudores",
                columns: table => new
                {
                    DeudorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoCedulaURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deudores", x => x.DeudorId);
                });

            migrationBuilder.CreateTable(
                name: "pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeudorId = table.Column<int>(type: "int", nullable: false),
                    Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PagoPendiente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeudorId = table.Column<int>(type: "int", nullable: false),
                    MontoPrestado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Interes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cuotas = table.Column<int>(type: "int", nullable: true),
                    FormaPago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaPrestamo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCobro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MontoCuota = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalInteres = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontoTotalPagar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prestamos", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_prestamos_deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "deudores",
                        principalColumn: "DeudorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cobros",
                columns: table => new
                {
                    CobroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeudorId = table.Column<int>(type: "int", nullable: false),
                    PrestamoId = table.Column<int>(type: "int", nullable: false),
                    Mora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ImportePagar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPrestamo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCobro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrestamosPrestamoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cobros", x => x.CobroId);
                    table.ForeignKey(
                        name: "FK_cobros_deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "deudores",
                        principalColumn: "DeudorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cobros_prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cobros_prestamos_PrestamosPrestamoId",
                        column: x => x.PrestamosPrestamoId,
                        principalTable: "prestamos",
                        principalColumn: "PrestamoId");
                });

            migrationBuilder.CreateTable(
                name: "facturas",
                columns: table => new
                {
                    FacturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeudorId = table.Column<int>(type: "int", nullable: false),
                    PagoId = table.Column<int>(type: "int", nullable: false),
                    PrestamoId = table.Column<int>(type: "int", nullable: false),
                    MontoFactura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CobrosCobroId = table.Column<int>(type: "int", nullable: true),
                    PagosPagoId = table.Column<int>(type: "int", nullable: true),
                    PrestamosPrestamoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facturas", x => x.FacturaId);
                    table.ForeignKey(
                        name: "FK_facturas_cobros_CobrosCobroId",
                        column: x => x.CobrosCobroId,
                        principalTable: "cobros",
                        principalColumn: "CobroId");
                    table.ForeignKey(
                        name: "FK_facturas_deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "deudores",
                        principalColumn: "DeudorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_facturas_pagos_PagoId",
                        column: x => x.PagoId,
                        principalTable: "pagos",
                        principalColumn: "PagoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_facturas_pagos_PagosPagoId",
                        column: x => x.PagosPagoId,
                        principalTable: "pagos",
                        principalColumn: "PagoId");
                    table.ForeignKey(
                        name: "FK_facturas_prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_facturas_prestamos_PrestamosPrestamoId",
                        column: x => x.PrestamosPrestamoId,
                        principalTable: "prestamos",
                        principalColumn: "PrestamoId");
                });

            migrationBuilder.CreateTable(
                name: "abonos",
                columns: table => new
                {
                    AbonoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    MontoAbono = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaAbono = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_abonos_FacturaId",
                table: "abonos",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_cobros_DeudorId",
                table: "cobros",
                column: "DeudorId");

            migrationBuilder.CreateIndex(
                name: "IX_cobros_PrestamoId",
                table: "cobros",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_cobros_PrestamosPrestamoId",
                table: "cobros",
                column: "PrestamosPrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_facturas_CobrosCobroId",
                table: "facturas",
                column: "CobrosCobroId");

            migrationBuilder.CreateIndex(
                name: "IX_facturas_DeudorId",
                table: "facturas",
                column: "DeudorId");

            migrationBuilder.CreateIndex(
                name: "IX_facturas_PagoId",
                table: "facturas",
                column: "PagoId");

            migrationBuilder.CreateIndex(
                name: "IX_facturas_PagosPagoId",
                table: "facturas",
                column: "PagosPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_facturas_PrestamoId",
                table: "facturas",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_facturas_PrestamosPrestamoId",
                table: "facturas",
                column: "PrestamosPrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_DeudorId",
                table: "pagos",
                column: "DeudorId");

            migrationBuilder.CreateIndex(
                name: "IX_prestamos_DeudorId",
                table: "prestamos",
                column: "DeudorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "abonos");

            migrationBuilder.DropTable(
                name: "facturas");

            migrationBuilder.DropTable(
                name: "cobros");

            migrationBuilder.DropTable(
                name: "pagos");

            migrationBuilder.DropTable(
                name: "prestamos");

            migrationBuilder.DropTable(
                name: "deudores");
        }
    }
}
