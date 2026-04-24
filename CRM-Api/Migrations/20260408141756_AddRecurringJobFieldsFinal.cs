using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddRecurringJobFieldsFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentJobId",
                schema: "task",
                table: "Job",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecurringMode",
                schema: "task",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 47, 55, 219, DateTimeKind.Local).AddTicks(9917));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 47, 55, 221, DateTimeKind.Local).AddTicks(4398));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 47, 55, 221, DateTimeKind.Local).AddTicks(4412));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 47, 55, 221, DateTimeKind.Local).AddTicks(4413));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 47, 55, 221, DateTimeKind.Local).AddTicks(4414));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 47, 55, 221, DateTimeKind.Local).AddTicks(4415));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 47, 55, 221, DateTimeKind.Local).AddTicks(4417));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 47, 55, 221, DateTimeKind.Local).AddTicks(4437));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 47, 55, 221, DateTimeKind.Local).AddTicks(4438));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 47, 55, 221, DateTimeKind.Local).AddTicks(4439));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentJobId",
                schema: "task",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "RecurringMode",
                schema: "task",
                table: "Job");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 17, 38, 25, 884, DateTimeKind.Local).AddTicks(2071));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 17, 38, 25, 885, DateTimeKind.Local).AddTicks(7279));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 17, 38, 25, 885, DateTimeKind.Local).AddTicks(7296));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 17, 38, 25, 885, DateTimeKind.Local).AddTicks(7298));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 17, 38, 25, 885, DateTimeKind.Local).AddTicks(7298));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 17, 38, 25, 885, DateTimeKind.Local).AddTicks(7299));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 17, 38, 25, 885, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 17, 38, 25, 885, DateTimeKind.Local).AddTicks(7301));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 17, 38, 25, 885, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 17, 38, 25, 885, DateTimeKind.Local).AddTicks(7303));
        }
    }
}
