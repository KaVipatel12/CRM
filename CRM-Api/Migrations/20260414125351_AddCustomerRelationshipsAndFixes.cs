using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerRelationshipsAndFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "cust",
                table: "CustomerNotes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CustomerRelationships",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceCustomerId = table.Column<int>(type: "int", nullable: false),
                    TargetCustomerId = table.Column<int>(type: "int", nullable: false),
                    RelationshipTypeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoOfShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRelationships", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerRelationships_Customers_SourceCustomerId",
                        column: x => x.SourceCustomerId,
                        principalSchema: "cust",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CustomerRelationships_Customers_TargetCustomerId",
                        column: x => x.TargetCustomerId,
                        principalSchema: "cust",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CustomerRelationships_RelationShipType_RelationshipTypeId",
                        column: x => x.RelationshipTypeId,
                        principalSchema: "cust",
                        principalTable: "RelationShipType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 297, DateTimeKind.Local).AddTicks(8675), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(954) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2284), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2286) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2287), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2288) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2289), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2289) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2290), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2291) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2292), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2292) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2293), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2293) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2295), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2295) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2296), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2297) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2297), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2298) });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRelationships_RelationshipTypeId",
                schema: "cust",
                table: "CustomerRelationships",
                column: "RelationshipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRelationships_SourceCustomerId",
                schema: "cust",
                table: "CustomerRelationships",
                column: "SourceCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRelationships_TargetCustomerId",
                schema: "cust",
                table: "CustomerRelationships",
                column: "TargetCustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerRelationships",
                schema: "cust");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "cust",
                table: "CustomerNotes");

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
        }
    }
}
