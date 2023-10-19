using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Primary_HealthCare_System.Migrations
{
    public partial class records : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medical_Record",
                columns: table => new
                {
                    RecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CounselorID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuesDiscussed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeworkAssigned = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Progress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FollowUpPlans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextSessionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PatientID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabResults = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Procedures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FollowUpInstructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medical_Record", x => x.RecordID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medical_Record");
        }
    }
}
