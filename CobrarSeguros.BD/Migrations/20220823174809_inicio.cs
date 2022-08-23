using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CobrarSeguros.BD.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    nroTelfonico = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patente = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    Sumasegurada = table.Column<int>(type: "int", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Polizas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nroPoliza = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    tipoSeguro = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    vigenciaPoliza = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    periodoPoliza = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polizas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Polizas_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Polizas_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ClienteDNI_UQ",
                table: "Cliente",
                column: "DNI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Polizas_VehiculoId",
                table: "Polizas",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "PolizadeVehiculo_UQ",
                table: "Polizas",
                columns: new[] { "ClienteId", "VehiculoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_ClienteId",
                table: "Vehiculos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "Vehiculo_UQ",
                table: "Vehiculos",
                column: "Patente",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Polizas");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
