using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Primary_HealthCare_System.Migrations
{
    public partial class referral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Referal",
                columns: table => new
                {
                    ReferralID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CounselingSessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferralDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferringDoctorID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferralReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referal", x => x.ReferralID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Referal");
        }
    }
}
