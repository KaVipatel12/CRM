using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class MakeAcnNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ACN",
                schema: "cust",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 1,
                column: "BusinessTypeNM",
                value: "Restaurant");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 2,
                column: "BusinessTypeNM",
                value: "Massage");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 3,
                column: "BusinessTypeNM",
                value: "Education agent");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 4,
                column: "BusinessTypeNM",
                value: "Car wash");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 5,
                column: "BusinessTypeNM",
                value: "Real estate agent");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 6,
                column: "BusinessTypeNM",
                value: "Mortgage broker");

            migrationBuilder.InsertData(
                schema: "cust",
                table: "BusinessType",
                columns: new[] { "Id", "BusinessTypeNM" },
                values: new object[,]
                {
                    { 7, "Cafe" },
                    { 8, "Roof restoration" },
                    { 9, "Tiler" },
                    { 10, "Plumber" },
                    { 11, "Electrician" },
                    { 12, "Air conditioner mechanic" },
                    { 13, "House builder" },
                    { 14, "Transport" },
                    { 15, "GYM" },
                    { 16, "Education institute" },
                    { 17, "Tattoo Artist" },
                    { 18, "Accounting Firm" },
                    { 19, "Panel Beater" },
                    { 20, "Painter" }
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 46, 17, 182, DateTimeKind.Local).AddTicks(3765));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 46, 17, 183, DateTimeKind.Local).AddTicks(6646));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 46, 17, 183, DateTimeKind.Local).AddTicks(6661));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 46, 17, 183, DateTimeKind.Local).AddTicks(6663));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 46, 17, 183, DateTimeKind.Local).AddTicks(6664));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 46, 17, 183, DateTimeKind.Local).AddTicks(6665));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 46, 17, 183, DateTimeKind.Local).AddTicks(6666));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 46, 17, 183, DateTimeKind.Local).AddTicks(6666));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 46, 17, 183, DateTimeKind.Local).AddTicks(6667));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 46, 17, 183, DateTimeKind.Local).AddTicks(6668));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "TradingStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Active But Not Trading");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "TradingStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Trading Quarterly");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "TradingStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Trading Annually");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "TradingStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Not active & not trading");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.AlterColumn<string>(
                name: "ACN",
                schema: "cust",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 1,
                column: "BusinessTypeNM",
                value: "Manufacturing");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 2,
                column: "BusinessTypeNM",
                value: "Retail");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 3,
                column: "BusinessTypeNM",
                value: "Technology");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 4,
                column: "BusinessTypeNM",
                value: "Hospitality");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 5,
                column: "BusinessTypeNM",
                value: "Construction");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 6,
                column: "BusinessTypeNM",
                value: "Other");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 10, 58, 48, 283, DateTimeKind.Local).AddTicks(3695));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 10, 58, 48, 284, DateTimeKind.Local).AddTicks(8577));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 10, 58, 48, 284, DateTimeKind.Local).AddTicks(8592));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 10, 58, 48, 284, DateTimeKind.Local).AddTicks(8594));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 10, 58, 48, 284, DateTimeKind.Local).AddTicks(8595));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 10, 58, 48, 284, DateTimeKind.Local).AddTicks(8601));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 10, 58, 48, 284, DateTimeKind.Local).AddTicks(8602));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 10, 58, 48, 284, DateTimeKind.Local).AddTicks(8603));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 10, 58, 48, 284, DateTimeKind.Local).AddTicks(8605));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 10, 58, 48, 284, DateTimeKind.Local).AddTicks(8606));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "TradingStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Trading");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "TradingStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Dormant");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "TradingStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Liquidated");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "TradingStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Deregistered");
        }
    }
}
