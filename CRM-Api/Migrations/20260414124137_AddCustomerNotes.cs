using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerNotes",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    NoteText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPinned = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerNotes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerNotes_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "cust",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 11, 36, 571, DateTimeKind.Local).AddTicks(356), new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(3250) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4249), new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4252) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4254), new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4254) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4255), new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4256) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4257), new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4257) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4258), new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4259) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4260), new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4260) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4261), new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4261) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4262), new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4263) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4264), new DateTime(2026, 4, 14, 18, 11, 36, 572, DateTimeKind.Local).AddTicks(4264) });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerNotes_CustomerId",
                schema: "cust",
                table: "CustomerNotes",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerNotes",
                schema: "cust");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 17, 44, 46, 475, DateTimeKind.Local).AddTicks(9729), new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(4723) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(5867), new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(5871) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(5873), new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(5873) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(5874), new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(5875) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(5875), new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(5876) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(5877), new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(5877) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(5878), new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(5879) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(5880), new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(5880) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(6058), new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(6059) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(6060), new DateTime(2026, 4, 14, 17, 44, 46, 477, DateTimeKind.Local).AddTicks(6061) });
        }
    }
}
