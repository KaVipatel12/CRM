using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class RestoreLegacyJobParityV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 437, DateTimeKind.Local).AddTicks(4628), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(933) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2171), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2173) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2175), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2175) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2177), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2177) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2178), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2179) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2180), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2180) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2182), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2182) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2183), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2184) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2185), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2185) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2186), new DateTime(2026, 4, 17, 12, 37, 31, 439, DateTimeKind.Local).AddTicks(2188) });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 2,
                column: "StatusName",
                value: "Active");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 3,
                column: "StatusName",
                value: "Client Confirmed");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 4,
                column: "StatusName",
                value: "Letter Drafted");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 5,
                column: "StatusName",
                value: "Ready for Lodgement");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 6,
                column: "StatusName",
                value: "Application Lodged");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 7,
                column: "StatusName",
                value: "Application further assessment");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 8,
                column: "StatusName",
                value: "Approved");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 9,
                column: "StatusName",
                value: "On Hold");

            migrationBuilder.InsertData(
                schema: "task",
                table: "JobStatusMaster",
                columns: new[] { "ID", "DisplayOrder", "ShowPriority", "StatusName" },
                values: new object[,]
                {
                    { 10, null, null, "Todo Later" },
                    { 11, null, null, "Payment made for invoice" },
                    { 12, null, null, "Completed" },
                    { 13, null, null, "Ready for Preparing" },
                    { 14, null, null, "FS Prepared" },
                    { 15, null, null, "Ready for tax return prep" },
                    { 16, null, null, "Tax Return prepared" },
                    { 17, null, null, "Ready for Checking Status" },
                    { 18, null, null, "Sent to Sign Declaration" },
                    { 19, null, null, "Ready for Bookkeeping" },
                    { 20, null, null, "Ready for FS Prepare" },
                    { 21, null, null, "Lodged" },
                    { 22, null, null, "Declaration Signed by Client" },
                    { 23, null, null, "Filed and Close Job" },
                    { 24, null, null, "Incomplete Documents" },
                    { 25, null, null, "Assigned Bookkeeper" },
                    { 26, null, null, "Suspended Confirmed" },
                    { 27, null, null, "Suspened Report" },
                    { 28, null, null, "BAS lodged" },
                    { 29, null, null, "Ready for Lodgement - client confirmed" },
                    { 30, null, null, "Ready for Lodgement - waiting client confirmation" },
                    { 31, null, null, "Filed" },
                    { 32, null, null, "Job Closed" },
                    { 33, null, null, "N/A" },
                    { 34, null, null, "Pending" },
                    { 35, null, null, "Continue" },
                    { 36, null, null, "Failed" },
                    { 37, null, null, "Collecting Doc" },
                    { 38, null, null, "Daparting AUS" },
                    { 39, null, null, "Sent to Hobart" },
                    { 40, null, null, "ATO Application Submitted" },
                    { 41, null, null, "Sent DOC to Super Fund" },
                    { 42, null, null, "Create Invoice" },
                    { 43, null, null, "Invoice Created" },
                    { 44, null, null, "Application been processed further" },
                    { 45, null, null, "Application Approved" },
                    { 46, null, null, "Client Enrollment Form Sent" },
                    { 47, null, null, "Ethical Letter Sent" },
                    { 48, null, null, "Docs Received from Accountant" },
                    { 49, null, null, "Mark as Active Client" },
                    { 50, null, null, "SSP CRM updated" },
                    { 51, null, null, "Waiting for Super details" }
                });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 1,
                column: "DisplayOrder",
                value: null);

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "DisplayOrder", "JobStatusMasterId" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "DisplayOrder", "JobStatusMasterId" },
                values: new object[] { null, 3 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "DisplayOrder", "JobStatusMasterId" },
                values: new object[] { null, 4 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "DisplayOrder", "JobStatusMasterId" },
                values: new object[] { null, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "DisplayOrder", "JobStatusMasterId" },
                values: new object[] { null, 6 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 7, 1 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 8, 1 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 9, 1 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 10, 1 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 11, 1 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 12, 1 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "DisplayOrder", "JobTypeId" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 13, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 14, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 15, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 16, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 17, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 18, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 19, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 20, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 21, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 22, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 23, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 10, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 9, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 11, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 12, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 29,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 1, 3 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 30,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 2, 3 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 31,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 11, 3 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 32,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 9, 3 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 33,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 10, 3 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 34,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 12, 3 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 35,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 1, 4 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 36,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 2, 4 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 37,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 10, 4 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 38,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 9, 4 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 39,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 11, 4 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 40,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 12, 4 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 41,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 1, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 42,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 24, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 43,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 25, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 44,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 26, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 45,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 27, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 46,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 5, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 47,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 17, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 48,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 28, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 49,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 29, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 50,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 30, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 51,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 31, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 52,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 32, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 53,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 11, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 54,
                columns: new[] { "DisplayOrder", "JobTypeId" },
                values: new object[] { null, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 55,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 10, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 56,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 12, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 57,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 1, 6 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 58,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 2, 6 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 59,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 10, 6 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 60,
                columns: new[] { "DisplayOrder", "JobTypeId" },
                values: new object[] { null, 6 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 61,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 11, 6 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 62,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 12, 6 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 63,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 33, 7 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 64,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 34, 7 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 65,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 35, 7 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 66,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 36, 7 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 67,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 10, 7 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 68,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 11, 7 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 69,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 9, 7 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 70,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 12, 7 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 71,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 1, 8 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 72,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 13, 8 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 73,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 14, 8 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 74,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 16, 8 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 75,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 18, 8 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 76,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 21, 8 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 77,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 23, 8 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 78,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 10, 8 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 79,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 9, 8 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 80,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 11, 8 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 81,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 12, 8 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 82,
                columns: new[] { "DisplayOrder", "JobTypeId" },
                values: new object[] { null, 9 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 83,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 2, 9 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 84,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 10, 9 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 85,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 11, 9 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 86,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 9, 9 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 87,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 12, 9 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 88,
                columns: new[] { "DisplayOrder", "JobTypeId" },
                values: new object[] { null, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 89,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 2, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 90,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 3, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 91,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 4, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 92,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 5, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 93,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 6, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 94,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 7, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 95,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 8, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 96,
                columns: new[] { "DisplayOrder", "JobTypeId" },
                values: new object[] { null, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 97,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 11, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 98,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { null, 10, 10 });

            migrationBuilder.InsertData(
                schema: "task",
                table: "JobTypeStatusMapping",
                columns: new[] { "ID", "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[,]
                {
                    { 100, null, 1, 11 },
                    { 101, null, 2, 11 },
                    { 104, null, 9, 11 },
                    { 110, null, 1, 12 },
                    { 111, null, 2, 12 },
                    { 112, null, 9, 12 },
                    { 116, null, 1, 13 },
                    { 124, null, 9, 13 },
                    { 126, null, 1, 14 },
                    { 136, null, 9, 14 },
                    { 140, null, 1, 15 },
                    { 141, null, 2, 15 },
                    { 144, null, 9, 15 },
                    { 146, null, 1, 16 },
                    { 147, null, 2, 16 },
                    { 148, null, 9, 16 },
                    { 152, null, 1, 17 },
                    { 153, null, 2, 17 },
                    { 156, null, 9, 17 },
                    { 158, null, 1, 18 },
                    { 169, null, 9, 18 },
                    { 171, null, 1, 19 },
                    { 172, null, 2, 19 },
                    { 173, null, 9, 19 },
                    { 177, null, 1, 20 },
                    { 178, null, 2, 20 },
                    { 181, null, 9, 20 },
                    { 185, null, 9, 21 },
                    { 188, null, 1, 22 },
                    { 189, null, 2, 22 },
                    { 190, null, 3, 22 },
                    { 191, null, 5, 22 },
                    { 192, null, 6, 22 },
                    { 197, null, 9, 22 },
                    { 199, null, 1, 23 },
                    { 200, null, 2, 23 },
                    { 201, null, 9, 23 }
                });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "ACT covid grant 2021" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "Annual Non GST" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "ASIC Updates" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "BAS" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "Bookkeeping" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "Business Registration" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "CallTracker" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "Company Tax Return" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "Comunication Email" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "Covid 19 2021 Payment" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "Covid 19 marketing Grant" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "CRE" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "DASP" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "Financial Statement" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "General" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "Group Certificate" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "GST" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "I Tax Return" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "Imported WIP" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "Invoice Creation" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "JBK declaration" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "Job Saver 2021" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { null, "Loan Application" });

            migrationBuilder.InsertData(
                schema: "task",
                table: "TypeMaster",
                columns: new[] { "ID", "Description", "ShortCode", "Type" },
                values: new object[,]
                {
                    { 24, null, null, "Micro covid grant 2021" },
                    { 25, null, null, "Monthly Instalment Activity" },
                    { 26, null, null, "New client" },
                    { 27, null, null, "Partnership Tax Return" },
                    { 28, null, null, "PAYG MONTHLY" },
                    { 29, null, null, "QId covid grant 2021" },
                    { 30, null, null, "SMSF" },
                    { 31, null, null, "Super Contribution" },
                    { 32, null, null, "SuperSetup" },
                    { 33, null, null, "Tax Return Amendment" },
                    { 34, null, null, "Todo" },
                    { 35, null, null, "WAGES" },
                    { 36, null, null, "Workers compensation" }
                });

            migrationBuilder.InsertData(
                schema: "task",
                table: "JobTypeStatusMapping",
                columns: new[] { "ID", "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[,]
                {
                    { 99, null, 12, 10 },
                    { 102, null, 10, 11 },
                    { 103, null, 11, 11 },
                    { 105, null, 12, 11 },
                    { 113, null, 10, 12 },
                    { 114, null, 11, 12 },
                    { 115, null, 12, 12 },
                    { 117, null, 37, 13 },
                    { 118, null, 38, 13 },
                    { 119, null, 39, 13 },
                    { 120, null, 40, 13 },
                    { 121, null, 41, 13 },
                    { 122, null, 11, 13 },
                    { 123, null, 10, 13 },
                    { 125, null, 12, 13 },
                    { 127, null, 13, 14 },
                    { 128, null, 14, 14 },
                    { 129, null, 15, 14 },
                    { 130, null, 16, 14 },
                    { 131, null, 17, 14 },
                    { 132, null, 18, 14 },
                    { 133, null, 21, 14 },
                    { 134, null, 22, 14 },
                    { 135, null, 23, 14 },
                    { 137, null, 11, 14 },
                    { 138, null, 10, 14 },
                    { 139, null, 12, 14 },
                    { 142, null, 10, 15 },
                    { 143, null, 11, 15 },
                    { 145, null, 12, 15 },
                    { 149, null, 11, 16 },
                    { 150, null, 10, 16 },
                    { 151, null, 12, 16 },
                    { 154, null, 10, 17 },
                    { 155, null, 11, 17 },
                    { 157, null, 12, 17 },
                    { 159, null, 13, 18 },
                    { 160, null, 14, 18 },
                    { 161, null, 15, 18 },
                    { 162, null, 16, 18 },
                    { 163, null, 18, 18 },
                    { 164, null, 21, 18 },
                    { 165, null, 22, 18 },
                    { 166, null, 23, 18 },
                    { 167, null, 10, 18 },
                    { 168, null, 11, 18 },
                    { 170, null, 12, 18 },
                    { 174, null, 11, 19 },
                    { 175, null, 10, 19 },
                    { 176, null, 12, 19 },
                    { 179, null, 42, 20 },
                    { 180, null, 43, 20 },
                    { 182, null, 11, 20 },
                    { 183, null, 10, 20 },
                    { 184, null, 12, 20 },
                    { 186, null, 11, 21 },
                    { 187, null, 10, 21 },
                    { 193, null, 44, 22 },
                    { 194, null, 45, 22 },
                    { 195, null, 11, 22 },
                    { 196, null, 10, 22 },
                    { 198, null, 12, 22 },
                    { 202, null, 10, 23 },
                    { 203, null, 11, 23 },
                    { 204, null, 12, 23 },
                    { 205, null, 1, 24 },
                    { 206, null, 2, 24 },
                    { 207, null, 3, 24 },
                    { 208, null, 5, 24 },
                    { 209, null, 6, 24 },
                    { 210, null, 45, 24 },
                    { 211, null, 11, 24 },
                    { 212, null, 10, 24 },
                    { 213, null, 9, 24 },
                    { 214, null, 12, 24 },
                    { 215, null, 1, 25 },
                    { 216, null, 2, 25 },
                    { 217, null, 21, 25 },
                    { 218, null, 10, 25 },
                    { 219, null, 11, 25 },
                    { 220, null, 9, 25 },
                    { 221, null, 12, 25 },
                    { 222, null, 1, 26 },
                    { 223, null, 2, 26 },
                    { 224, null, 46, 26 },
                    { 225, null, 47, 26 },
                    { 226, null, 48, 26 },
                    { 227, null, 49, 26 },
                    { 228, null, 50, 26 },
                    { 229, null, 9, 26 },
                    { 230, null, 11, 26 },
                    { 231, null, 10, 26 },
                    { 232, null, 12, 26 },
                    { 233, null, 1, 27 },
                    { 234, null, 13, 27 },
                    { 235, null, 14, 27 },
                    { 236, null, 16, 27 },
                    { 237, null, 18, 27 },
                    { 238, null, 21, 27 },
                    { 239, null, 23, 27 },
                    { 240, null, 9, 27 },
                    { 241, null, 10, 27 },
                    { 242, null, 11, 27 },
                    { 243, null, 12, 27 },
                    { 244, null, 1, 28 },
                    { 245, null, 2, 28 },
                    { 246, null, 11, 28 },
                    { 247, null, 10, 28 },
                    { 248, null, 9, 28 },
                    { 249, null, 12, 28 },
                    { 250, null, 1, 29 },
                    { 251, null, 2, 29 },
                    { 252, null, 3, 29 },
                    { 253, null, 4, 29 },
                    { 254, null, 5, 29 },
                    { 255, null, 6, 29 },
                    { 256, null, 7, 29 },
                    { 257, null, 8, 29 },
                    { 258, null, 9, 29 },
                    { 259, null, 10, 29 },
                    { 260, null, 11, 29 },
                    { 261, null, 12, 29 },
                    { 262, null, 1, 30 },
                    { 263, null, 2, 30 },
                    { 264, null, 10, 30 },
                    { 265, null, 11, 30 },
                    { 266, null, 9, 30 },
                    { 267, null, 12, 30 },
                    { 268, null, 1, 31 },
                    { 269, null, 2, 31 },
                    { 270, null, 51, 31 },
                    { 271, null, 21, 31 },
                    { 272, null, 9, 31 },
                    { 273, null, 11, 31 },
                    { 274, null, 10, 31 },
                    { 275, null, 12, 31 },
                    { 276, null, 1, 32 },
                    { 277, null, 2, 32 },
                    { 278, null, 10, 32 },
                    { 279, null, 11, 32 },
                    { 280, null, 9, 32 },
                    { 281, null, 12, 32 },
                    { 282, null, 1, 33 },
                    { 283, null, 13, 33 },
                    { 284, null, 14, 33 },
                    { 285, null, 16, 33 },
                    { 286, null, 18, 33 },
                    { 287, null, 21, 33 },
                    { 288, null, 23, 33 },
                    { 289, null, 9, 33 },
                    { 290, null, 11, 33 },
                    { 291, null, 10, 33 },
                    { 292, null, 12, 33 },
                    { 293, null, 1, 34 },
                    { 294, null, 2, 34 },
                    { 295, null, 9, 34 },
                    { 296, null, 11, 34 },
                    { 297, null, 10, 34 },
                    { 298, null, 12, 34 },
                    { 299, null, 1, 35 },
                    { 300, null, 2, 35 },
                    { 301, null, 9, 35 },
                    { 302, null, 10, 35 },
                    { 303, null, 11, 35 },
                    { 304, null, 12, 35 },
                    { 305, null, 1, 36 },
                    { 306, null, 2, 36 },
                    { 307, null, 11, 36 },
                    { 308, null, 10, 36 },
                    { 309, null, 9, 36 },
                    { 310, null, 12, 36 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 101);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 102);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 103);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 104);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 105);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 110);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 111);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 112);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 113);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 114);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 115);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 116);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 117);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 118);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 119);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 120);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 121);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 122);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 123);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 124);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 125);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 126);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 127);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 128);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 129);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 130);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 131);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 132);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 133);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 134);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 135);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 136);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 137);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 138);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 139);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 140);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 141);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 142);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 143);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 144);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 145);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 146);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 147);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 148);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 149);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 150);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 151);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 152);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 153);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 154);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 155);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 156);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 157);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 158);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 159);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 160);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 161);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 162);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 163);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 164);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 165);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 166);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 167);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 168);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 169);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 170);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 171);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 172);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 173);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 174);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 175);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 176);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 177);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 178);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 179);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 180);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 181);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 182);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 183);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 184);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 185);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 186);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 187);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 188);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 189);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 190);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 191);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 192);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 193);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 194);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 195);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 196);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 197);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 198);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 199);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 200);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 201);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 202);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 203);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 204);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 205);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 206);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 207);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 208);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 209);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 210);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 211);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 212);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 213);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 214);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 215);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 216);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 217);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 218);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 219);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 220);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 221);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 222);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 223);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 224);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 225);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 226);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 227);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 228);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 229);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 230);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 231);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 232);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 233);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 234);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 235);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 236);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 237);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 238);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 239);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 240);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 241);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 242);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 243);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 244);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 245);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 246);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 247);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 248);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 249);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 250);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 251);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 252);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 253);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 254);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 255);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 256);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 257);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 258);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 259);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 260);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 261);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 262);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 263);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 264);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 265);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 266);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 267);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 268);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 269);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 270);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 271);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 272);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 273);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 274);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 275);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 276);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 277);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 278);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 279);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 280);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 281);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 282);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 283);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 284);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 285);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 286);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 287);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 288);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 289);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 290);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 291);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 292);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 293);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 294);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 295);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 296);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 297);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 298);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 299);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 300);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 301);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 302);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 303);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 304);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 305);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 306);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 307);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 308);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 309);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 310);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 11, 30, 9, 461, DateTimeKind.Local).AddTicks(1076), new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(1112) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2657), new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2660) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2661), new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2662) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2663), new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2664) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2665), new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2666) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2667), new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2667) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2668), new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2668) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2669), new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2670) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2671), new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2671) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2672), new DateTime(2026, 4, 17, 11, 30, 9, 464, DateTimeKind.Local).AddTicks(2673) });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 2,
                column: "StatusName",
                value: "Allocated");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 3,
                column: "StatusName",
                value: "Active");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 4,
                column: "StatusName",
                value: "Pending");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 5,
                column: "StatusName",
                value: "Pre-Interview");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 6,
                column: "StatusName",
                value: "Draft");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 7,
                column: "StatusName",
                value: "Interviewed");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 8,
                column: "StatusName",
                value: "Finalising");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 9,
                column: "StatusName",
                value: "Complete");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 1,
                column: "DisplayOrder",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "DisplayOrder", "JobStatusMasterId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "DisplayOrder", "JobStatusMasterId" },
                values: new object[] { 3, 4 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "DisplayOrder", "JobStatusMasterId" },
                values: new object[] { 4, 6 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "DisplayOrder", "JobStatusMasterId" },
                values: new object[] { 5, 8 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "DisplayOrder", "JobStatusMasterId" },
                values: new object[] { 6, 9 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 1, 1, 3 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 3 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 4, 3 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 4, 6, 3 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 5, 8, 3 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 6, 9, 3 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "DisplayOrder", "JobTypeId" },
                values: new object[] { 1, 6 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 6 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 4, 6 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 4, 6, 6 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 5, 8, 6 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 6, 9, 6 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 1, 1, 9 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 9 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 4, 9 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 4, 6, 9 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 5, 8, 9 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 6, 9, 9 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 1, 1, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 4, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 4, 6, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 29,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 5, 8, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 30,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 6, 9, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 31,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 1, 1, 13 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 32,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 13 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 33,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 4, 13 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 34,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 4, 6, 13 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 35,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 5, 8, 13 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 36,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 6, 9, 13 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 37,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 1, 1, 14 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 38,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 14 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 39,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 4, 14 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 40,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 4, 6, 14 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 41,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 5, 8, 14 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 42,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 6, 9, 14 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 43,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 1, 1, 16 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 44,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 16 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 45,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 4, 16 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 46,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 4, 6, 16 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 47,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 5, 8, 16 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 48,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 6, 9, 16 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 49,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 1, 1, 17 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 50,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 17 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 51,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 4, 17 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 52,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 4, 6, 17 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 53,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 5, 8, 17 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 54,
                columns: new[] { "DisplayOrder", "JobTypeId" },
                values: new object[] { 6, 17 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 55,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 1, 1, 18 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 56,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 18 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 57,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 4, 18 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 58,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 4, 6, 18 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 59,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 5, 8, 18 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 60,
                columns: new[] { "DisplayOrder", "JobTypeId" },
                values: new object[] { 6, 18 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 61,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 1, 1, 19 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 62,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 19 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 63,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 4, 19 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 64,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 4, 6, 19 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 65,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 5, 8, 19 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 66,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 6, 9, 19 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 67,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 1, 1, 21 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 68,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 21 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 69,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 4, 21 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 70,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 4, 6, 21 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 71,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 5, 8, 21 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 72,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 6, 9, 21 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 73,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 1, 1, 22 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 74,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 22 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 75,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 4, 22 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 76,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 4, 6, 22 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 77,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 5, 8, 22 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 78,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 6, 9, 22 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 79,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 1, 1, 11 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 80,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 11 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 81,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 9, 11 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 82,
                columns: new[] { "DisplayOrder", "JobTypeId" },
                values: new object[] { 1, 23 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 83,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 23 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 84,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 9, 23 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 85,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 1, 1, 8 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 86,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 8 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 87,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 9, 8 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 88,
                columns: new[] { "DisplayOrder", "JobTypeId" },
                values: new object[] { 1, 7 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 89,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 7 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 90,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 9, 7 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 91,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 1, 1, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 92,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 93,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 9, 5 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 94,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 95,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 96,
                columns: new[] { "DisplayOrder", "JobTypeId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 97,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 5, 14 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 98,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 4, 7, 14 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "AA", "Annual Accounts" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "ASIC", "ASIC Updates" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "BAS", "BAS" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "BK", "Bookkeeping " });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "BREG", "Business Registration" });

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

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "WAGES", "WAGES" });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "TypeMaster",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "ShortCode", "Type" },
                values: new object[] { "EMAIL", "Comunication Email" });
        }
    }
}
