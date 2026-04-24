using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDeleteToServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "cust",
                table: "CustomerServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 413, DateTimeKind.Local).AddTicks(3642), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(51) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1750), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1753) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1755), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1755) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1757), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1757) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1758), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1759) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1760), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1760) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1761), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1762) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1765), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1765) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1766), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1767) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1768), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1769) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5123), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5127) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5722), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5725) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5727), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5727) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5728), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5729) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5730), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5730) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5731), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5732) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5733), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5733) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5735), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5735) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5736), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5737) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5738), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5738) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "cust",
                table: "CustomerServices");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 967, DateTimeKind.Local).AddTicks(6649), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(3246) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4552), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4555) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4558), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4558) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4559), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4560) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4561), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4561) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4562), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4563) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4564), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4564) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4565), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4566) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4599), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4599) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4600), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4601) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(8610), new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(8613) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9200), new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9202) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9205), new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9206) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9207), new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9207) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9208), new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9209) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9210), new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9210) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9211), new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9212) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9220), new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9220) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9222), new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9222) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9223), new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9223) });
        }
    }
}
