using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaMedica.Migrations
{
    public partial class AddForeignKeyTurnos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCitas_CitasMedicas_CitaMedicaId",
                table: "DetalleCitas");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCitas_Servicios_ServicioId",
                table: "DetalleCitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Horarios_HorarioId",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Medicos_MedicoId",
                table: "Turnos");

            migrationBuilder.AddColumn<int>(
                name: "HorariosHorarioId",
                table: "Turnos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicosMedicoId",
                table: "Turnos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PacientesPacienteId",
                table: "Turnos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_HorariosHorarioId",
                table: "Turnos",
                column: "HorariosHorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_MedicosMedicoId",
                table: "Turnos",
                column: "MedicosMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_PacienteId",
                table: "Turnos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_PacientesPacienteId",
                table: "Turnos",
                column: "PacientesPacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCitas_CitasMedicas_CitaMedicaId",
                table: "DetalleCitas",
                column: "CitaMedicaId",
                principalTable: "CitasMedicas",
                principalColumn: "CitaMedicaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCitas_Servicios_ServicioId",
                table: "DetalleCitas",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "ServicioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Horarios_HorarioId",
                table: "Turnos",
                column: "HorarioId",
                principalTable: "Horarios",
                principalColumn: "HorarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Horarios_HorariosHorarioId",
                table: "Turnos",
                column: "HorariosHorarioId",
                principalTable: "Horarios",
                principalColumn: "HorarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Medicos_MedicoId",
                table: "Turnos",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "MedicoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Medicos_MedicosMedicoId",
                table: "Turnos",
                column: "MedicosMedicoId",
                principalTable: "Medicos",
                principalColumn: "MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Pacientes_PacienteId",
                table: "Turnos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "PacienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Pacientes_PacientesPacienteId",
                table: "Turnos",
                column: "PacientesPacienteId",
                principalTable: "Pacientes",
                principalColumn: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCitas_CitasMedicas_CitaMedicaId",
                table: "DetalleCitas");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCitas_Servicios_ServicioId",
                table: "DetalleCitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Horarios_HorarioId",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Horarios_HorariosHorarioId",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Medicos_MedicoId",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Medicos_MedicosMedicoId",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Pacientes_PacienteId",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Pacientes_PacientesPacienteId",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_HorariosHorarioId",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_MedicosMedicoId",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_PacienteId",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_PacientesPacienteId",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "HorariosHorarioId",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "MedicosMedicoId",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "PacientesPacienteId",
                table: "Turnos");

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
    }
}
