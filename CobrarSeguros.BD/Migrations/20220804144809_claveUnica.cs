using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CobrarSeguros.BD.Migrations
{
    public partial class claveUnica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "Vehiculo_UQ",
                table: "Vehiculos",
                columns: new[] { "Patente", "nroPoliza" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ClienteDNI_UQ",
                table: "Cliente",
                column: "DNI",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Vehiculo_UQ",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "ClienteDNI_UQ",
                table: "Cliente");
        }
    }
}
