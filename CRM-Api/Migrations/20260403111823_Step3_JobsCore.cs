using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class Step3_JobsCore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedule",
                schema: "task",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    DayOfWeek = table.Column<int>(type: "int", nullable: true),
                    DayOfMonth = table.Column<int>(type: "int", nullable: true),
                    ScheduleDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDuration = table.Column<int>(type: "int", nullable: true),
                    DueMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Detail",
                schema: "task",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleID = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    TypeID = table.Column<int>(type: "int", nullable: false),
                    PeriodEnded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskOwner = table.Column<int>(type: "int", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserID = table.Column<int>(type: "int", nullable: true),
                    AssignTo = table.Column<int>(type: "int", nullable: true),
                    AssignBy = table.Column<int>(type: "int", nullable: true),
                    IsRecurring = table.Column<bool>(type: "bit", nullable: true),
                    PerformAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Detail_Schedule_ScheduleID",
                        column: x => x.ScheduleID,
                        principalSchema: "task",
                        principalTable: "Schedule",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Action",
                schema: "task",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleID = table.Column<int>(type: "int", nullable: true),
                    DetailID = table.Column<int>(type: "int", nullable: true),
                    ActionMasterID = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutionStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    ExecutionStartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExecutionEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    ExecutionEndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBackground = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    PerformAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskOwner = table.Column<int>(type: "int", nullable: true),
                    AssignTo = table.Column<int>(type: "int", nullable: true),
                    EmailJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRunning = table.Column<bool>(type: "bit", nullable: false),
                    NoOfTry = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stage = table.Column<int>(type: "int", nullable: true),
                    DueDuration = table.Column<int>(type: "int", nullable: true),
                    DueMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "date", nullable: true),
                    ClosedBy = table.Column<int>(type: "int", nullable: true),
                    ClosedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: true),
                    AssignDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Action_Detail_DetailID",
                        column: x => x.DetailID,
                        principalSchema: "task",
                        principalTable: "Detail",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Action_Schedule_ScheduleID",
                        column: x => x.ScheduleID,
                        principalSchema: "task",
                        principalTable: "Schedule",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Action_DetailID",
                schema: "task",
                table: "Action",
                column: "DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Action_ScheduleID",
                schema: "task",
                table: "Action",
                column: "ScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_ScheduleID",
                schema: "task",
                table: "Detail",
                column: "ScheduleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Action",
                schema: "task");

            migrationBuilder.DropTable(
                name: "Detail",
                schema: "task");

            migrationBuilder.DropTable(
                name: "Schedule",
                schema: "task");
        }
    }
}
