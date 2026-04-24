using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveActionConfigAddVaultConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionConfiguration",
                schema: "setting");

            migrationBuilder.CreateTable(
                name: "VaultConfiguration",
                schema: "setting",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaultConfiguration", x => x.ID);
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 504, DateTimeKind.Local).AddTicks(2370), new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(6772) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7948), new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7950) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7952), new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7952) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7953), new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7953) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7955), new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7956) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7956), new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7957) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7958), new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7958) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7959), new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7960) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7961), new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7961) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7962), new DateTime(2026, 4, 23, 15, 55, 40, 505, DateTimeKind.Local).AddTicks(7963) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(2670), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(2672) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(3685), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(3688) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(4643), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(4645) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7029), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7031) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7036), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7036) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7039), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7039) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7041), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7042) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7043), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7044) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7047), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7047) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7049), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7049) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7051), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7052) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7053), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7054) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7056), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7056) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7058), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7058) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7100), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7100) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7102), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7103) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7105), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7106) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7108), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7108) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7110), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7111) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7112), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7113) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7115), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7116) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7118), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7118) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7120), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7121) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7122), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7123) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7125), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7126) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7127), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7128) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7446), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7449) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7452), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7453) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7456), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7456) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7459), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7459) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 29,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7461), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7462) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 30,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7464), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(7466) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(853), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(862) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1701), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1704) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1706), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1707) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1708), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1709) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1710), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1710) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1711), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1712) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1714), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1714) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1715), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1715) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1717), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1717) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1774), new DateTime(2026, 4, 23, 15, 55, 40, 508, DateTimeKind.Local).AddTicks(1775) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaultConfiguration",
                schema: "setting");

            migrationBuilder.CreateTable(
                name: "ActionConfiguration",
                schema: "setting",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CCEmail1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCEmail2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    FromEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordManagerPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMTPHost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMTPPort = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionConfiguration", x => x.ID);
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 118, DateTimeKind.Local).AddTicks(9034), new DateTime(2026, 4, 23, 15, 48, 33, 151, DateTimeKind.Local).AddTicks(7376) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(765), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(769) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(774), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(774) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(776), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(776) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(777), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(777) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(778), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(780) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(781), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(781) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(782), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(782) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(784), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(950) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(957), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(957) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(5320), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(5323) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(6434), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(6436) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(7439), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(7442) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9941), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9944) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9948), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9949) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9951), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9952) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9954), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9954) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9957), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9958) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9961), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9961) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9964), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9964) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9966), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9967) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9969), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9970) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9972), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9972) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9984), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9984) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(27), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(27) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(30), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(30) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(33), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(33) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(35), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(36) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(37), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(38) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(40), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(40) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(43), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(44) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(45), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(46) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(48), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(48) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(198), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(199) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(202), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(203) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(205), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(206) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(543), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(549), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(549) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(552), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(553) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(556), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(556) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 29,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(558), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(559) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 30,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(561), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(562) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3112), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3125) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3910), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3912) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3915), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3916) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3917), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3918) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3919), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3919) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3920), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3921) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3922), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3923) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3924), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3925) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3926), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3926) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3984), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3984) });
        }
    }
}
