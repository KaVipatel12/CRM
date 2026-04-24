using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AutoFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 49, 33, 89, DateTimeKind.Local).AddTicks(9678));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 49, 33, 91, DateTimeKind.Local).AddTicks(3834));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 49, 33, 91, DateTimeKind.Local).AddTicks(3848));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 49, 33, 91, DateTimeKind.Local).AddTicks(3849));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 49, 33, 91, DateTimeKind.Local).AddTicks(3850));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 49, 33, 91, DateTimeKind.Local).AddTicks(3851));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 49, 33, 91, DateTimeKind.Local).AddTicks(3852));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 49, 33, 91, DateTimeKind.Local).AddTicks(3853));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 49, 33, 91, DateTimeKind.Local).AddTicks(3854));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 49, 33, 91, DateTimeKind.Local).AddTicks(3855));
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
    }
}
