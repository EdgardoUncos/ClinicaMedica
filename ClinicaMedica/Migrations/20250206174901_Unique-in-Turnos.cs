using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaMedica.Migrations
{
    public partial class UniqueinTurnos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Turnos_HorarioId",
                table: "Turnos");

            migrationBuilder.CreateIndex(
                name: "UQ_Turnos_Horario_Medico_Fecha",
                table: "Turnos",
                columns: new[] { "HorarioId", "MedicoId", "Fecha" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_Turnos_Horario_Medico_Fecha",
                table: "Turnos");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_HorarioId",
                table: "Turnos",
                column: "HorarioId");
        }
    }
}
