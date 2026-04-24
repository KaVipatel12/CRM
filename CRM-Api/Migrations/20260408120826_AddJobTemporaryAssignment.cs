using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddJobTemporaryAssignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OriginalResponsibleId",
                schema: "task",
                table: "Job",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TemporaryAssignmentNote",
                schema: "task",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TemporaryAssignmentUntil",
                schema: "task",
                table: "Job",
                type: "datetime2",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalResponsibleId",
                schema: "task",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "TemporaryAssignmentNote",
                schema: "task",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "TemporaryAssignmentUntil",
                schema: "task",
                table: "Job");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 15, 25, 55, 495, DateTimeKind.Local).AddTicks(3577));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 15, 25, 55, 496, DateTimeKind.Local).AddTicks(6282));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 15, 25, 55, 496, DateTimeKind.Local).AddTicks(6295));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 15, 25, 55, 496, DateTimeKind.Local).AddTicks(6297));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 15, 25, 55, 496, DateTimeKind.Local).AddTicks(6298));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 15, 25, 55, 496, DateTimeKind.Local).AddTicks(6298));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 15, 25, 55, 496, DateTimeKind.Local).AddTicks(6299));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 15, 25, 55, 496, DateTimeKind.Local).AddTicks(6300));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 15, 25, 55, 496, DateTimeKind.Local).AddTicks(6301));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 15, 25, 55, 496, DateTimeKind.Local).AddTicks(6302));
        }
    }
}
