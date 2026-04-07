using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class OptimizedJobManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Job",
                schema: "task",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    JobTypeId = table.Column<int>(type: "int", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CurrentStage = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Job_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "cust",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_JobStatusMaster_CurrentStage",
                        column: x => x.CurrentStage,
                        principalSchema: "task",
                        principalTable: "JobStatusMaster",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Job_TypeMaster_JobTypeId",
                        column: x => x.JobTypeId,
                        principalSchema: "task",
                        principalTable: "TypeMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobComment",
                schema: "task",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobComment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JobComment_Job_JobId",
                        column: x => x.JobId,
                        principalSchema: "task",
                        principalTable: "Job",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobHistory",
                schema: "task",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JobHistory_Job_JobId",
                        column: x => x.JobId,
                        principalSchema: "task",
                        principalTable: "Job",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobTask",
                schema: "task",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTask", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JobTask_Job_JobId",
                        column: x => x.JobId,
                        principalSchema: "task",
                        principalTable: "Job",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 43, 9, 8, DateTimeKind.Local).AddTicks(9848));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 43, 9, 10, DateTimeKind.Local).AddTicks(3304));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 43, 9, 10, DateTimeKind.Local).AddTicks(3319));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 43, 9, 10, DateTimeKind.Local).AddTicks(3321));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 43, 9, 10, DateTimeKind.Local).AddTicks(3322));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 43, 9, 10, DateTimeKind.Local).AddTicks(3323));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 43, 9, 10, DateTimeKind.Local).AddTicks(3324));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 43, 9, 10, DateTimeKind.Local).AddTicks(3325));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 43, 9, 10, DateTimeKind.Local).AddTicks(3326));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 43, 9, 10, DateTimeKind.Local).AddTicks(3327));

            migrationBuilder.CreateIndex(
                name: "IX_Job_CurrentStage",
                schema: "task",
                table: "Job",
                column: "CurrentStage");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CustomerId",
                schema: "task",
                table: "Job",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_JobTypeId",
                schema: "task",
                table: "Job",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobComment_JobId",
                schema: "task",
                table: "JobComment",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobHistory_JobId",
                schema: "task",
                table: "JobHistory",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTask_JobId",
                schema: "task",
                table: "JobTask",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobComment",
                schema: "task");

            migrationBuilder.DropTable(
                name: "JobHistory",
                schema: "task");

            migrationBuilder.DropTable(
                name: "JobTask",
                schema: "task");

            migrationBuilder.DropTable(
                name: "Job",
                schema: "task");

            migrationBuilder.CreateTable(
                name: "Schedule",
                schema: "task",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DayOfMonth = table.Column<int>(type: "int", nullable: true),
                    DayOfWeek = table.Column<int>(type: "int", nullable: true),
                    DueDuration = table.Column<int>(type: "int", nullable: true),
                    DueMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    Mode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true)
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
                    TypeID = table.Column<int>(type: "int", nullable: false),
                    AssignBy = table.Column<int>(type: "int", nullable: true),
                    AssignTo = table.Column<int>(type: "int", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRecurring = table.Column<bool>(type: "bit", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodEnded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    Stage = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    TaskOwner = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserID = table.Column<int>(type: "int", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Detail_TypeMaster_TypeID",
                        column: x => x.TypeID,
                        principalSchema: "task",
                        principalTable: "TypeMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Action",
                schema: "task",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailID = table.Column<int>(type: "int", nullable: true),
                    ScheduleID = table.Column<int>(type: "int", nullable: true),
                    ActionMasterID = table.Column<int>(type: "int", nullable: true),
                    AssignDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignTo = table.Column<int>(type: "int", nullable: true),
                    ClosedBy = table.Column<int>(type: "int", nullable: true),
                    ClosedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "date", nullable: true),
                    DueDuration = table.Column<int>(type: "int", nullable: true),
                    DueMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutionEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    ExecutionEndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExecutionStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    ExecutionStartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBackground = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsRunning = table.Column<bool>(type: "bit", nullable: false),
                    NoOfTry = table.Column<int>(type: "int", nullable: false),
                    PerformAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    Stage = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    TaskOwner = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdUserID = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 724, DateTimeKind.Local).AddTicks(5250));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5389));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5407));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5408));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5410));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5411));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5412));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5413));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5414));

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

            migrationBuilder.CreateIndex(
                name: "IX_Detail_TypeID",
                schema: "task",
                table: "Detail",
                column: "TypeID");
        }
    }
}
