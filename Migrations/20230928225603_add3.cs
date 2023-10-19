using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Primary_HealthCare_System.Migrations
{
    public partial class add3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Counselling_Sessions",
                columns: table => new
                {
                    SessionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CounsellorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppointemtID = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counselling_Sessions", x => x.SessionID);
                    table.ForeignKey(
                        name: "FK_Counselling_Sessions_Appointments_AppointemtID",
                        column: x => x.AppointemtID,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId");
                    table.ForeignKey(
                        name: "FK_Counselling_Sessions_AspNetUsers_CounsellorID",
                        column: x => x.CounsellorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Counselling_Sessions_AppointemtID",
                table: "Counselling_Sessions",
                column: "AppointemtID");

            migrationBuilder.CreateIndex(
                name: "IX_Counselling_Sessions_CounsellorID",
                table: "Counselling_Sessions",
                column: "CounsellorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Counselling_Sessions");
        }
    }
}
