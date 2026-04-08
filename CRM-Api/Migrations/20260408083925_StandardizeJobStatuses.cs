using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class StandardizeJobStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 14, 9, 24, 840, DateTimeKind.Local).AddTicks(215));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 14, 9, 24, 841, DateTimeKind.Local).AddTicks(4276));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 14, 9, 24, 841, DateTimeKind.Local).AddTicks(4288));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 14, 9, 24, 841, DateTimeKind.Local).AddTicks(4290));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 14, 9, 24, 841, DateTimeKind.Local).AddTicks(4291));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 14, 9, 24, 841, DateTimeKind.Local).AddTicks(4292));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 14, 9, 24, 841, DateTimeKind.Local).AddTicks(4293));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 14, 9, 24, 841, DateTimeKind.Local).AddTicks(4294));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 14, 9, 24, 841, DateTimeKind.Local).AddTicks(4295));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 14, 9, 24, 841, DateTimeKind.Local).AddTicks(4296));

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 2,
                column: "StatusName",
                value: "Active");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 3,
                column: "StatusName",
                value: "On Hold");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 4,
                column: "StatusName",
                value: "Todo Later");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 5,
                column: "StatusName",
                value: "Payment made for invoice");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 6,
                column: "StatusName",
                value: "Completed");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 13, 53, 1, 134, DateTimeKind.Local).AddTicks(6135));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 13, 53, 1, 136, DateTimeKind.Local).AddTicks(1103));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 13, 53, 1, 136, DateTimeKind.Local).AddTicks(1119));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 13, 53, 1, 136, DateTimeKind.Local).AddTicks(1120));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 13, 53, 1, 136, DateTimeKind.Local).AddTicks(1121));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 13, 53, 1, 136, DateTimeKind.Local).AddTicks(1122));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 13, 53, 1, 136, DateTimeKind.Local).AddTicks(1123));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 13, 53, 1, 136, DateTimeKind.Local).AddTicks(1125));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 13, 53, 1, 136, DateTimeKind.Local).AddTicks(1126));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 13, 53, 1, 136, DateTimeKind.Local).AddTicks(1127));

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 2,
                column: "StatusName",
                value: "Allocated");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 3,
                column: "StatusName",
                value: "Active");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 4,
                column: "StatusName",
                value: "Pending");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 5,
                column: "StatusName",
                value: "Pre-Interview");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 6,
                column: "StatusName",
                value: "Draft");

            migrationBuilder.InsertData(
                schema: "task",
                table: "JobStatusMaster",
                columns: new[] { "ID", "DisplayOrder", "ShowPriority", "StatusName" },
                values: new object[,]
                {
                    { 7, null, null, "Interviewed" },
                    { 8, null, null, "Finalising" },
                    { 9, null, null, "Complete" }
                });
        }
    }
}
