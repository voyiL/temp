using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Primary_HealthCare_System.Migrations
{
    public partial class alerts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    AlertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntendedUser = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.AlertId);
                    table.ForeignKey(
                        name: "FK_Alerts_AspNetUsers_IntendedUser",
                        column: x => x.IntendedUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CounselorID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    OverallRating = table.Column<int>(type: "int", nullable: false),
                    CommunicationRating = table.Column<int>(type: "int", nullable: false),
                    EffectivenessRating = table.Column<int>(type: "int", nullable: false),
                    ComfortRating = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FeedbackID);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_IntendedUser",
                table: "Alerts",
                column: "IntendedUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Referal");
        }
    }
}
