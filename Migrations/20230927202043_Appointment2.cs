using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Primary_HealthCare_System.Migrations
{
    public partial class Appointment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientID",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientID",
                table: "Appointments",
                column: "PatientID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientID",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "Appointments");
        }
    }
}
