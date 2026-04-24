using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSmtpSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "setting");

            migrationBuilder.CreateTable(
                name: "SmtpSettings",
                schema: "setting",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncryptedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCEmailsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmtpSettings", x => x.ID);
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 778, DateTimeKind.Local).AddTicks(5779), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(7694) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8621), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8624) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8626), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8626) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8627), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8628) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8629), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8629) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8630), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8631) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8632), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8632) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8633), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8634) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8635), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8635) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8636), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8637) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(319), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(322) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(1256), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(1260) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(2174), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(2177) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5069), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5072) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5076), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5076) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5079), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5079) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5081), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5082) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5085), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5085) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5088), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5089) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5091), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5091) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5094), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5095) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5098), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5099) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5100), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5101) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5103), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5103) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5131), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5131) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5133), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5134) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5136), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5136) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5138), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5138) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5140), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5141) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5143), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5143) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5145), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5146) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5148), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5148) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5159), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5160) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5162), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5162) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5164), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5164) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5166), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5167) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5487), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5490) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5494), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5494) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5499), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5499) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5502), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5502) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 29,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5504), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5505) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 30,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5507), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5507) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(8696), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(8706) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9407), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9410) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9412), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9412) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9414), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9414) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9415), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9416) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9417), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9417) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9418), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9419) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9420), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9420) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9421), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9422) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9463), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9463) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmtpSettings",
                schema: "setting");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 695, DateTimeKind.Local).AddTicks(7776), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(1678) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2767), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2769) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2771), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2771) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2772), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2773) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2843), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2843) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2844), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2845) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2846), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2847) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2848), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2848) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2849), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2850) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2851), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2851) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(7262), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(7264) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(8080), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(8082) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(8870), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(8873) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(834), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(836) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(875), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(875) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(877), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(878) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(880), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(880) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(882), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(882) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(884), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(884) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(886), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(886) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(888), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(889) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(890), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(891) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(892), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(893) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(895), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(895) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(907), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(907) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(909), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(910) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(911), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(912) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(914), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(914) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(918), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(918) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(920), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(920) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(922), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(922) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(924), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(924) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(926), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(927) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(928), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(929) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(931), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(931) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(933), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(933) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1217), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1219) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1222), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1222) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1224), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1224) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1226), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1227) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 29,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1228), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1229) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 30,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1231), new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1231) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(5660), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(5663) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6477), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6479) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6481), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6481) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6483), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6483) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6484), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6485) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6486), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6486) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6487), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6488) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6489), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6489) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6490), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6490) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6492), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6492) });
        }
    }
}
