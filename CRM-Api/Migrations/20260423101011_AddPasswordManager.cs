using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PasswordManager",
                schema: "setting",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordManager", x => x.ID);
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 517, DateTimeKind.Local).AddTicks(9006), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(1493) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2872), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2874) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2878), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2878) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2879), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2880) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2881), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2882) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2883), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2884) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2885), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2886) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2887), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2888) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2889), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2889) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2890), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2890) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(9374), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(9377) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(365), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(367) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(1319), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(1323) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3735), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3737) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3741), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3741) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3744), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3744) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3746), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3747) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3748), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3749) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3751), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3751) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3753), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3753) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3755), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3756) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3757), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3758) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3760), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3760) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3762), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3762) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3797), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3798) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3800), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3800) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3802), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3803) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3804), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3805) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3814), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3815) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3817), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3817) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3820), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3820) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3823), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3823) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3826), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3827) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3829), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3829) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3831), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3832) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3834), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3834) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4162), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4164) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4168), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4168) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4170), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4171) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4173), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4174) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 29,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4176), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4176) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 30,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4178), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4179) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(7805), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(7810) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8503), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8505) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8507), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8507) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8509), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8509) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8510), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8511) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8512), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8512) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8513), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8514) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8515), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8515) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8517), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8517) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8556), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8556) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordManager",
                schema: "setting");

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
        }
    }
}
