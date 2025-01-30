using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaMedica.Migrations
{
    public partial class RelationShipHorarioTurnos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Turnos_HorarioId",
                table: "Turnos",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_MedicoId",
                table: "Turnos",
                column: "MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Horarios_HorarioId",
                table: "Turnos",
                column: "HorarioId",
                principalTable: "Horarios",
                principalColumn: "HorarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Medicos_MedicoId",
                table: "Turnos",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "MedicoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Horarios_HorarioId",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Medicos_MedicoId",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_HorarioId",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_MedicoId",
                table: "Turnos");
        }
    }
}
