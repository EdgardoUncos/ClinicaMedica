using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaMedica.Migrations
{
    public partial class addestado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitasMedicas_Medicos_MedicoId",
                table: "CitasMedicas");

            migrationBuilder.DropForeignKey(
                name: "FK_CitasMedicas_Pacientes_PacienteId",
                table: "CitasMedicas");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCitas_CitasMedicas_CitaMedicaId",
                table: "DetalleCitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Horarios_HorariosHorarioId",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Medicos_MedicosMedicoId",
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
                name: "IX_Turnos_PacientesPacienteId",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "HorariosHorarioId",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "MedicosMedicoId",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "PacientesPacienteId",
                table: "Turnos");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "Turnos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Turnos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Disponible");

            migrationBuilder.AddForeignKey(
                name: "FK_CitasMedicas_Medicos_MedicoId",
                table: "CitasMedicas",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CitasMedicas_Pacientes_PacienteId",
                table: "CitasMedicas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCitas_CitasMedicas_CitaMedicaId",
                table: "DetalleCitas",
                column: "CitaMedicaId",
                principalTable: "CitasMedicas",
                principalColumn: "CitaMedicaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitasMedicas_Medicos_MedicoId",
                table: "CitasMedicas");

            migrationBuilder.DropForeignKey(
                name: "FK_CitasMedicas_Pacientes_PacienteId",
                table: "CitasMedicas");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCitas_CitasMedicas_CitaMedicaId",
                table: "DetalleCitas");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Turnos");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "IX_Turnos_PacientesPacienteId",
                table: "Turnos",
                column: "PacientesPacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_CitasMedicas_Medicos_MedicoId",
                table: "CitasMedicas",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "MedicoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CitasMedicas_Pacientes_PacienteId",
                table: "CitasMedicas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "PacienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCitas_CitasMedicas_CitaMedicaId",
                table: "DetalleCitas",
                column: "CitaMedicaId",
                principalTable: "CitasMedicas",
                principalColumn: "CitaMedicaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Horarios_HorariosHorarioId",
                table: "Turnos",
                column: "HorariosHorarioId",
                principalTable: "Horarios",
                principalColumn: "HorarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Medicos_MedicosMedicoId",
                table: "Turnos",
                column: "MedicosMedicoId",
                principalTable: "Medicos",
                principalColumn: "MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Pacientes_PacientesPacienteId",
                table: "Turnos",
                column: "PacientesPacienteId",
                principalTable: "Pacientes",
                principalColumn: "PacienteId");
        }
    }
}
