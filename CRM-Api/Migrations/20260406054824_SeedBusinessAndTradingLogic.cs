using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedBusinessAndTradingLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.InsertData(
                schema: "cust",
                table: "BusinessType",
                columns: new[] { "Id", "BusinessTypeNM" },
                values: new object[,]
                {
                    { 1, "Manufacturing" },
                    { 2, "Retail" },
                    { 3, "Technology" },
                    { 4, "Hospitality" },
                    { 5, "Construction" },
                    { 6, "Other" }
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 18, 22, 128, DateTimeKind.Local).AddTicks(8098));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 18, 22, 130, DateTimeKind.Local).AddTicks(1377));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 18, 22, 130, DateTimeKind.Local).AddTicks(1390));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 18, 22, 130, DateTimeKind.Local).AddTicks(1392));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 18, 22, 130, DateTimeKind.Local).AddTicks(1393));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 18, 22, 130, DateTimeKind.Local).AddTicks(1393));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 18, 22, 130, DateTimeKind.Local).AddTicks(1395));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 18, 22, 130, DateTimeKind.Local).AddTicks(1396));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 18, 22, 130, DateTimeKind.Local).AddTicks(1398));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                column: "UpdDT",
                value: new DateTime(2026, 4, 6, 11, 18, 22, 130, DateTimeKind.Local).AddTicks(1398));

            migrationBuilder.InsertData(
                schema: "cust",
                table: "TaxAgent",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Internal Agent" },
                    { 2, "External Agent" }
                });

            migrationBuilder.InsertData(
                schema: "cust",
                table: "TradingStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Trading" },
                    { 2, "Dormant" },
                    { 3, "Liquidated" },
                    { 4, "Deregistered" }
                });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "COMP", "Compliance" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "FBT", "FBT" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "GQ", "General Queries" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "FINS", "Financial Statements" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "ITR", "Income Tax Return" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "IAS", "IAS" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "PAYG", "PAYG Summary" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "PR", "Payroll" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "WC", "Work Cover" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "TFN", "TFN Declaration" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "STPF", "STP Finalisation" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "OTH", "Others" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "PR T", "Payroll Tax" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "SGC", "Superannuation Guarantee" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "TPAR", "Taxable Payments Annual Repor" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "REG", "TFN/ABN/PAYG Registration " });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "BusinessType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "TaxAgent",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "TaxAgent",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "TradingStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "TradingStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "TradingStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "cust",
                table: "TradingStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                column: "UpdDT",
                value: new DateTime(2026, 4, 3, 18, 23, 54, 71, DateTimeKind.Local).AddTicks(6034));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                column: "UpdDT",
                value: new DateTime(2026, 4, 3, 18, 23, 54, 72, DateTimeKind.Local).AddTicks(8975));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                column: "UpdDT",
                value: new DateTime(2026, 4, 3, 18, 23, 54, 72, DateTimeKind.Local).AddTicks(9001));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                column: "UpdDT",
                value: new DateTime(2026, 4, 3, 18, 23, 54, 72, DateTimeKind.Local).AddTicks(9002));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                column: "UpdDT",
                value: new DateTime(2026, 4, 3, 18, 23, 54, 72, DateTimeKind.Local).AddTicks(9003));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                column: "UpdDT",
                value: new DateTime(2026, 4, 3, 18, 23, 54, 72, DateTimeKind.Local).AddTicks(9004));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                column: "UpdDT",
                value: new DateTime(2026, 4, 3, 18, 23, 54, 72, DateTimeKind.Local).AddTicks(9005));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                column: "UpdDT",
                value: new DateTime(2026, 4, 3, 18, 23, 54, 72, DateTimeKind.Local).AddTicks(9005));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                column: "UpdDT",
                value: new DateTime(2026, 4, 3, 18, 23, 54, 72, DateTimeKind.Local).AddTicks(9007));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                column: "UpdDT",
                value: new DateTime(2026, 4, 3, 18, 23, 54, 72, DateTimeKind.Local).AddTicks(9008));

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "CTR", "Company Tax Return" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "CRE", "CRE" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "DASP", "DASP" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "FBT", "FBT" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "FS", "Financial Statement" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "GEN", "General" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "GRPCER", "Group Certificate" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "GST", "GST" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "ITR", "I Tax Return" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "IMPWIP", "Imported WIP" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "PTR", "Partnership Tax Return" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "PAYGM", "PAYG MONTHLY" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "SMSF", "SMSF" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "SPRCON", "Super Contribution" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "SPRSET", "SuperSetup" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "TRA", "Tax Return Amendment" });

            migrationBuilder.InsertData(
                schema: "task",
                table: "TypeMaster",
                columns: new[] { "ID", "Description", "ShortCode", "Type" },
                values: new object[,]
                {
                    { 22, null, "WAGES", "WAGES" },
                    { 23, null, "EMAIL", "Comunication Email" }
                });
        }
    }
}
