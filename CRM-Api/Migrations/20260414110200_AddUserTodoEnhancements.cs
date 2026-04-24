using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTodoEnhancements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "user",
                table: "UserNotes",
                newName: "ID");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "UserTodos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "UserTodos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 16, 31, 59, 44, DateTimeKind.Local).AddTicks(3576), new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(6970) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8284), new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8287) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8289), new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8289) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8291), new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8291) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8292), new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8292) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8293), new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8294) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8295), new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8295) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8296), new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8297) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8298), new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8298) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8299), new DateTime(2026, 4, 14, 16, 31, 59, 45, DateTimeKind.Local).AddTicks(8300) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "UserTodos");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "UserTodos");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "user",
                table: "UserNotes",
                newName: "Id");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 13, 56, 3, 584, DateTimeKind.Local).AddTicks(9422), new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(2375) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3562), new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3566) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3567), new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3568) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3569), new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3569) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3570), new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3571) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3572), new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3572) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3573), new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3574) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3575), new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3576) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3576), new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3577) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3578), new DateTime(2026, 4, 14, 13, 56, 3, 586, DateTimeKind.Local).AddTicks(3578) });
        }
    }
}
