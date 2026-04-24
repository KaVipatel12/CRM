using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCallTracker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purpose",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurposeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purpose", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Calllogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Receiver = table.Column<int>(type: "int", nullable: true),
                    ForWhom = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Purpose = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: true),
                    OtherPurpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NatureOfBusiness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherNatureOfBusiness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HearAboutUs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherHearAboutUs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calllogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Calllogs_JobStatusMaster_Status",
                        column: x => x.Status,
                        principalSchema: "task",
                        principalTable: "JobStatusMaster",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Calllogs_Purpose_Purpose",
                        column: x => x.Purpose,
                        principalTable: "Purpose",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CallLogComments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallLogId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallLogComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CallLogComments_Calllogs_CallLogId",
                        column: x => x.CallLogId,
                        principalTable: "Calllogs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 293, DateTimeKind.Local).AddTicks(8877), new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(1311) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4042), new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4051) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4058), new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4060) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4062), new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4062) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4064), new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4064) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4065), new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4066) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4066), new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4067) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4068), new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4068) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4070), new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4071) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4072), new DateTime(2026, 4, 22, 16, 13, 27, 299, DateTimeKind.Local).AddTicks(4072) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(3306), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(3311) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(4925), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(4929) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(5996), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(5999) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8212), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8214) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8218), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8218) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8221), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8221) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8223), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8224) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8228), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8228) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8230), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8231) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8233), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8233) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8235), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8236) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8238), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8239) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8241), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8241) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8244), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8244) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8288), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8288) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8291), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8291) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8293), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8294) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8295), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8296) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8298), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8298) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8300), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8301) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8303), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8303) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8305), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8306) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8406), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8406) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8409), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8410) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8412), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8412) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8417), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(8417) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(9597), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(9601) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(9607), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(9607) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(9610), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(9610) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(9613), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(9613) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 29,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(9615), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(9616) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 30,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(9618), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(9618) });

            migrationBuilder.InsertData(
                table: "Purpose",
                columns: new[] { "ID", "IsActive", "PurposeName" },
                values: new object[,]
                {
                    { 1, true, "Meeting" },
                    { 2, true, "Call Back" },
                    { 3, true, "Potential Client" },
                    { 4, true, "Require Information" },
                    { 5, true, "Business Registration" },
                    { 6, true, "Loan" },
                    { 7, true, "Doing Accounting: BAS / Tax Return" },
                    { 8, true, "Advise: Business / Tax" },
                    { 9, true, "Superannuation: Rollover / SMSF" },
                    { 10, true, "Others" }
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(1415), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(1426) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2137), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2142) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2144), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2145) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2146), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2147) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2148), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2148) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2149), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2150) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2151), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2152) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2153), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2153) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2154), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2155) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2217), new DateTime(2026, 4, 22, 16, 13, 27, 302, DateTimeKind.Local).AddTicks(2218) });

            migrationBuilder.CreateIndex(
                name: "IX_CallLogComments_CallLogId",
                table: "CallLogComments",
                column: "CallLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Calllogs_Purpose",
                table: "Calllogs",
                column: "Purpose");

            migrationBuilder.CreateIndex(
                name: "IX_Calllogs_Status",
                table: "Calllogs",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallLogComments");

            migrationBuilder.DropTable(
                name: "Calllogs");

            migrationBuilder.DropTable(
                name: "Purpose");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 594, DateTimeKind.Local).AddTicks(208), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(5196) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(6996), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(6998) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7001), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7002) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7003), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7003) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7005), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7005) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7006), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7007) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7008), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7008) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7009), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7010) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7014), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7015) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7016), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7017) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(986), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(989) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(1919), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(1921) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(2827), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(2830) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5316), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5318) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5323), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5323) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5326), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5326) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5330), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5330) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5332), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5332) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5334), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5335) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5349), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5349) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5351), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5352) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5353), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5354) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5356), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5357) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5359), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5359) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5390), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5390) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5392), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5393) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5395), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5396) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5398), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5398) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5400), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5401) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5402), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5403) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5405), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5405) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5407), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5408) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5409), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5410) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5412), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5412) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5418), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5419) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5420), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5421) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5719), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5721) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5725), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5725) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5727), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5728) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5730), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5731) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 29,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5733), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5733) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 30,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5735), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5736) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 597, DateTimeKind.Local).AddTicks(9420), new DateTime(2026, 4, 21, 18, 25, 40, 597, DateTimeKind.Local).AddTicks(9441) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(113), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(115) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(117), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(118) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(119), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(119) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(120), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(121) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(122), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(122) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(124), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(125), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(126) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(127), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(127) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(179), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(180) });
        }
    }
}
