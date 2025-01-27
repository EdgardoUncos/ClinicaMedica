using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaMedica.Migrations
{
    public partial class DetalleCitas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DetalleCitas_ServicioId",
                table: "DetalleCitas",
                column: "ServicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCitas_CitasMedicas_CitaMedicaId",
                table: "DetalleCitas",
                column: "CitaMedicaId",
                principalTable: "CitasMedicas",
                principalColumn: "CitaMedicaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCitas_Servicios_ServicioId",
                table: "DetalleCitas",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "ServicioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCitas_CitasMedicas_CitaMedicaId",
                table: "DetalleCitas");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCitas_Servicios_ServicioId",
                table: "DetalleCitas");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCitas_ServicioId",
                table: "DetalleCitas");
        }
    }
}
