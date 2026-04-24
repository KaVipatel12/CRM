using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddServicePortfolio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceMaster",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerServices",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    InternalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerServices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerServices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "cust",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerServices_ServiceMaster_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "cust",
                        principalTable: "ServiceMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 967, DateTimeKind.Local).AddTicks(6649), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(3246) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4552), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4555) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4558), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4558) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4559), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4560) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4561), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4561) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4562), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4563) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4564), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4564) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4565), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4566) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4599), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4599) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4600), new DateTime(2026, 4, 17, 18, 32, 38, 969, DateTimeKind.Local).AddTicks(4601) });

            migrationBuilder.InsertData(
                schema: "cust",
                table: "ServiceMaster",
                columns: new[] { "ID", "CreatedDT", "CreatedUserID", "Description", "Name", "UpdDT", "UpdUserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(8610), null, "Preparation of year-end financial reports", "Annual Financial Statements", new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(8613), null },
                    { 2, new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9200), null, "Company or Trust income tax return filing", "Annual Tax Return", new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9202), null },
                    { 3, new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9205), null, "Goods and Services Tax / Business Activity Statement preparation", "GST/BAS Services", new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9206), null },
                    { 4, new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9207), null, "Regular data entry and bank reconciliation", "Bookkeeping", new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9207), null },
                    { 5, new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9208), null, "Weekly/Monthly payroll processing and PAYG", "Payroll Services", new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9209), null },
                    { 6, new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9210), null, "Annual review and company secretarial services", "ASIC Compliance", new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9210), null },
                    { 7, new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9211), null, "FBT return preparation", "Fringe Benefits Tax", new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9212), null },
                    { 8, new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9220), null, "Annual declaration and management", "Workers Compensation", new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9220), null },
                    { 9, new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9222), null, "Self-Managed Super Fund compliance", "SMSF Audit & Tax", new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9222), null },
                    { 10, new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9223), null, "Strategic business and tax advice", "General Consulting", new DateTime(2026, 4, 17, 18, 32, 38, 970, DateTimeKind.Local).AddTicks(9223), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServices_CustomerId",
                schema: "cust",
                table: "CustomerServices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServices_ServiceId",
                schema: "cust",
                table: "CustomerServices",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerServices",
                schema: "cust");

            migrationBuilder.DropTable(
                name: "ServiceMaster",
                schema: "cust");

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
        }
    }
}
