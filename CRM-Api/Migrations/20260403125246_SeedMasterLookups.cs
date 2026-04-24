using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedMasterLookups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "cust",
                table: "ContactType",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 6, "Deregistered" },
                    { 7, "Moved to other accountants" },
                    { 8, "Bad clients" }
                });

            migrationBuilder.InsertData(
                schema: "cust",
                table: "CustomerType",
                columns: new[] { "ID", "CustomerTypeNM", "EntityTypeID", "UpdDT", "UpdUserID" },
                values: new object[,]
                {
                    { 1, "Individual", null, new DateTime(2026, 4, 3, 18, 22, 45, 739, DateTimeKind.Local).AddTicks(7028), null },
                    { 2, "Company", null, new DateTime(2026, 4, 3, 18, 22, 45, 741, DateTimeKind.Local).AddTicks(250), null },
                    { 3, "Sole Proprietor", null, new DateTime(2026, 4, 3, 18, 22, 45, 741, DateTimeKind.Local).AddTicks(268), null },
                    { 4, "Trust", null, new DateTime(2026, 4, 3, 18, 22, 45, 741, DateTimeKind.Local).AddTicks(270), null },
                    { 5, "AKA", null, new DateTime(2026, 4, 3, 18, 22, 45, 741, DateTimeKind.Local).AddTicks(271), null },
                    { 6, "Partnership", null, new DateTime(2026, 4, 3, 18, 22, 45, 741, DateTimeKind.Local).AddTicks(272), null },
                    { 7, "SMSF", null, new DateTime(2026, 4, 3, 18, 22, 45, 741, DateTimeKind.Local).AddTicks(273), null },
                    { 8, "Staff", null, new DateTime(2026, 4, 3, 18, 22, 45, 741, DateTimeKind.Local).AddTicks(274), null },
                    { 9, "Supplier", null, new DateTime(2026, 4, 3, 18, 22, 45, 741, DateTimeKind.Local).AddTicks(275), null },
                    { 10, "Other", null, new DateTime(2026, 4, 3, 18, 22, 45, 741, DateTimeKind.Local).AddTicks(276), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "cust",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10);
        }
    }
}
