using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddDynamicFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "DynamicFieldMasters",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FieldType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FieldAbbreviation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Options = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicFieldMasters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DynamicFieldValues",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    FieldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicFieldValues", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DynamicFieldValues_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "cust",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DynamicFieldValues_DynamicFieldMasters_FieldId",
                        column: x => x.FieldId,
                        principalSchema: "dbo",
                        principalTable: "DynamicFieldMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_DynamicFieldValues_CustomerId",
                schema: "dbo",
                table: "DynamicFieldValues",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicFieldValues_FieldId",
                schema: "dbo",
                table: "DynamicFieldValues",
                column: "FieldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DynamicFieldValues",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DynamicFieldMasters",
                schema: "dbo");

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
    }
}
