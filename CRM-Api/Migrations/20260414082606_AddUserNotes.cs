using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.CreateTable(
                name: "UserNotes",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPinned = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotes_AspNetUsers_UserId",
                        column: x => x.UserId,
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

            migrationBuilder.CreateIndex(
                name: "IX_UserNotes_UserId",
                schema: "user",
                table: "UserNotes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserNotes",
                schema: "user");

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
        }
    }
}
