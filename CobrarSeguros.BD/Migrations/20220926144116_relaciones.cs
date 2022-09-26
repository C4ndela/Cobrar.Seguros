using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prueba.BD.Migrations
{
    public partial class relaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patente = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    Sumasegurada = table.Column<int>(type: "int", nullable: false),
                    ClientesId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Cliente_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Polizas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empresaAseguradora = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    nroPoliza = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    tipoSeguro = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    vigenciaPoliza = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    periodoPoliza = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    vencimientoFactura = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    linkAsegurador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polizas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Polizas_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Poliza.VehiculoID_UQ",
                table: "Polizas",
                columns: new[] { "VehiculoId", "nroPoliza" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_ClientesId",
                table: "Vehiculos",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "VehiculoID_UQ",
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
