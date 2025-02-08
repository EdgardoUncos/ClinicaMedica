using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaMedica.Migrations
{
    public partial class addquantitydetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "DetalleCitas",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "DetalleCitas");
        }
    }
}
