using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaMedica.Migrations
{
    public partial class ApiFluentServiciosetc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCitas_Servicios_ServicioId",
                table: "DetalleCitas");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Servicios",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Paquetes",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateTable(
                name: "PaquetesServicios",
                columns: table => new
                {
                    PaqueteId = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaquetesServicios", x => new { x.PaqueteId, x.ServicioId });
                    table.ForeignKey(
                        name: "FK_PaquetesServicios_Paquetes_PaqueteId",
                        column: x => x.PaqueteId,
                        principalTable: "Paquetes",
                        principalColumn: "PaqueteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaquetesServicios_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaquetesServicios_ServicioId",
                table: "PaquetesServicios",
                column: "ServicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCitas_Servicios_ServicioId",
                table: "DetalleCitas",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "ServicioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCitas_Servicios_ServicioId",
                table: "DetalleCitas");

            migrationBuilder.DropTable(
                name: "PaquetesServicios");

            migrationBuilder.AlterColumn<float>(
                name: "Precio",
                table: "Servicios",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<float>(
                name: "Precio",
                table: "Paquetes",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCitas_Servicios_ServicioId",
                table: "DetalleCitas",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "ServicioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
