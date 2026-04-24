using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusColorsAndIcons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                schema: "task",
                table: "JobStatusMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                schema: "task",
                table: "JobStatusMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 13, 57, 44, 350, DateTimeKind.Local).AddTicks(3177), new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(6823) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7842), new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7845) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7846), new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7847) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7848), new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7848) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7849), new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7850) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7851), new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7851) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7852), new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7853) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7854), new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7854) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7855), new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7864) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7865), new DateTime(2026, 4, 17, 13, 57, 44, 351, DateTimeKind.Local).AddTicks(7866) });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "gray", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "blue", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "orange", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "orange", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "indigo", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "indigo", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "purple", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "emerald", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "rose", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "rose", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "emerald", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "emerald", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "gray", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "orange", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "gray", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "orange", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "orange", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "orange", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "gray", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "gray", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "indigo", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "orange", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "emerald", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "rose", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "gray", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "rose", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "rose", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "indigo", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 29,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "indigo", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 30,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "orange", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 31,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "emerald", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 32,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "emerald", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 33,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "gray", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 34,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "orange", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 35,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "blue", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 36,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "rose", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 37,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "gray", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 38,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "gray", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 39,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "purple", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 40,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "indigo", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 41,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "indigo", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 42,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "blue", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 43,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "blue", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 44,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "purple", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 45,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "emerald", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 46,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "gray", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 47,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "orange", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 48,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "emerald", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 49,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "emerald", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 50,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "emerald", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 51,
                columns: new[] { "Color", "Icon" },
                values: new object[] { "orange", null });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 6,
                column: "JobStatusMasterId",
                value: 7);

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 7,
                column: "JobStatusMasterId",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 8,
                column: "JobStatusMasterId",
                value: 9);

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 9,
                column: "JobStatusMasterId",
                value: 10);

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 10,
                column: "JobStatusMasterId",
                value: 11);

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 11,
                column: "JobStatusMasterId",
                value: 12);

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 12,
                column: "JobStatusMasterId",
                value: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                schema: "task",
                table: "JobStatusMaster");

            migrationBuilder.DropColumn(
                name: "Icon",
                schema: "task",
                table: "JobStatusMaster");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 437, DateTimeKind.Local).AddTicks(4628), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(933) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2171), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2173) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2175), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2175) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2177), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2177) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2178), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2179) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2180), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2180) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2182), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2182) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2183), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2184) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2185), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2185) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2186), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2188) });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 6,
                column: "JobStatusMasterId",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 7,
                column: "JobStatusMasterId",
                value: 7);

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 8,
                column: "JobStatusMasterId",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 9,
                column: "JobStatusMasterId",
                value: 9);

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 10,
                column: "JobStatusMasterId",
                value: 10);

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 11,
                column: "JobStatusMasterId",
                value: 11);

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 12,
                column: "JobStatusMasterId",
                value: 12);
        }
    }
}
