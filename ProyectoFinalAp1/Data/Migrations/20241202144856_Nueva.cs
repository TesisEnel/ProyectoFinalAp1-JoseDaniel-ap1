using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalAp1.Migrations
{
    /// <inheritdoc />
    public partial class Nueva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeudorId = table.Column<int>(type: "int", nullable: false),
                    MontoPrestado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Interes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    CobradorId = table.Column<int>(type: "int", nullable: false),
                    Mora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ImportePagar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPrestamo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCobro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeudoresDeudorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cobros", x => x.CobroId);
                    table.ForeignKey(
                        name: "FK_cobros_cobradores_CobradorId",
                        column: x => x.CobradorId,
                        principalTable: "cobradores",
                        principalColumn: "CobradorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cobros_deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "deudores",
                        principalColumn: "DeudorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cobros_deudores_DeudoresDeudorId",
                        column: x => x.DeudoresDeudorId,
                        principalTable: "deudores",
                        principalColumn: "DeudorId");
                    table.ForeignKey(
                        name: "FK_cobros_prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "facturas",
                columns: table => new
                {
                    FacturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeudorId = table.Column<int>(type: "int", nullable: false),
                    PrestamoId = table.Column<int>(type: "int", nullable: false),
                    MontoFactura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facturas", x => x.FacturaId);
                    table.ForeignKey(
                        name: "FK_facturas_deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "deudores",
                        principalColumn: "DeudorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_facturas_prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "garantias",
                columns: table => new
                {
                    GarantiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoGarantia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorGarantia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaGarantia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FotoGarantiaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeudorId = table.Column<int>(type: "int", nullable: false),
                    PrestamoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_garantias", x => x.GarantiaId);
                    table.ForeignKey(
                        name: "FK_garantias_deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "deudores",
                        principalColumn: "DeudorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_garantias_prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cobrosDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CobroId = table.Column<int>(type: "int", nullable: false),
                    PrestamoId = table.Column<int>(type: "int", nullable: false),
                    ValorCobrado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cobrosDetalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_cobrosDetalles_cobros_CobroId",
                        column: x => x.CobroId,
                        principalTable: "cobros",
                        principalColumn: "CobroId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cobrosDetalles_prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cobros_CobradorId",
                table: "cobros",
                column: "CobradorId");

            migrationBuilder.CreateIndex(
                name: "IX_cobros_DeudoresDeudorId",
                table: "cobros",
                column: "DeudoresDeudorId");

            migrationBuilder.CreateIndex(
                name: "IX_cobros_DeudorId",
                table: "cobros",
                column: "DeudorId");

            migrationBuilder.CreateIndex(
                name: "IX_cobros_PrestamoId",
                table: "cobros",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_cobrosDetalles_CobroId",
                table: "cobrosDetalles",
                column: "CobroId");

            migrationBuilder.CreateIndex(
                name: "IX_cobrosDetalles_PrestamoId",
                table: "cobrosDetalles",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_facturas_DeudorId",
                table: "facturas",
                column: "DeudorId");

            migrationBuilder.CreateIndex(
                name: "IX_facturas_PrestamoId",
                table: "facturas",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_garantias_DeudorId",
                table: "garantias",
                column: "DeudorId");

            migrationBuilder.CreateIndex(
                name: "IX_garantias_PrestamoId",
                table: "garantias",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_prestamos_DeudorId",
                table: "prestamos",
                column: "DeudorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cobrosDetalles");

            migrationBuilder.DropTable(
                name: "facturas");

            migrationBuilder.DropTable(
                name: "garantias");

            migrationBuilder.DropTable(
                name: "cobros");

            migrationBuilder.DropTable(
                name: "cobradores");

            migrationBuilder.DropTable(
                name: "prestamos");

            migrationBuilder.DropTable(
                name: "deudores");
        }
    }
}
