using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Primary_HealthCare_System.Migrations
{
    public partial class appointmentsAddedPatientId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_MAinUSerId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "MAinUSerId",
                table: "Appointments",
                newName: "PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_MAinUSerId",
                table: "Appointments",
                newName: "IX_Appointments_PatientID");

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

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "Appointments",
                newName: "MAinUSerId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments",
                newName: "IX_Appointments_MAinUSerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_MAinUSerId",
                table: "Appointments",
                column: "MAinUSerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
