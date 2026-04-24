using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTodos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTodos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTodos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserTodos_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 11, 0, 29, 916, DateTimeKind.Local).AddTicks(2724), new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(5945) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6942), new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6944) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6947), new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6947) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6949), new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6949) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6950), new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6951) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6957), new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6958) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6959), new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6959) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6960), new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6961) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6962), new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6962) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6963), new DateTime(2026, 4, 14, 11, 0, 29, 917, DateTimeKind.Local).AddTicks(6964) });

            migrationBuilder.CreateIndex(
                name: "IX_UserTodos_UserID",
                table: "UserTodos",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTodos");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 251, DateTimeKind.Local).AddTicks(8259), new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(4544) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6192), new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6196) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6199), new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6199) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6200), new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6201) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6202), new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6203) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6204), new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6204) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6206), new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6206) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6207), new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6208) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6208), new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6209) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6210), new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6210) });
        }
    }
}
