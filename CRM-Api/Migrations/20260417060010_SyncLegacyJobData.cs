using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class SyncLegacyJobData : Migration
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

            migrationBuilder.InsertData(
                schema: "task",
                table: "JobStatusMaster",
                columns: new[] { "ID", "DisplayOrder", "ShowPriority", "StatusName" },
                values: new object[,]
                {
                    { 7, null, null, "Interviewed" },
                    { 8, null, null, "Finalising" },
                    { 9, null, null, "Complete" }
                });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 1,
                column: "JobTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 4, 1 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 4, 6, 1 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 5, 8, 1 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 6, 9, 1 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 1, 1, 3 });

            migrationBuilder.InsertData(
                schema: "task",
                table: "JobTypeStatusMapping",
                columns: new[] { "ID", "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[,]
                {
                    { 8, 2, 3, 3 },
                    { 9, 3, 4, 3 },
                    { 10, 4, 6, 3 },
                    { 13, 1, 1, 6 },
                    { 14, 2, 3, 6 },
                    { 15, 3, 4, 6 },
                    { 16, 4, 6, 6 },
                    { 19, 1, 1, 9 },
                    { 20, 2, 3, 9 },
                    { 21, 3, 4, 9 },
                    { 22, 4, 6, 9 },
                    { 25, 1, 1, 10 },
                    { 26, 2, 3, 10 },
                    { 27, 3, 4, 10 },
                    { 28, 4, 6, 10 },
                    { 31, 1, 1, 13 },
                    { 32, 2, 3, 13 },
                    { 33, 3, 4, 13 },
                    { 34, 4, 6, 13 },
                    { 37, 1, 1, 14 },
                    { 38, 2, 3, 14 },
                    { 39, 3, 4, 14 },
                    { 40, 4, 6, 14 },
                    { 43, 1, 1, 16 },
                    { 44, 2, 3, 16 },
                    { 45, 3, 4, 16 },
                    { 46, 4, 6, 16 },
                    { 49, 1, 1, 17 },
                    { 50, 2, 3, 17 },
                    { 51, 3, 4, 17 },
                    { 52, 4, 6, 17 },
                    { 55, 1, 1, 18 },
                    { 56, 2, 3, 18 },
                    { 57, 3, 4, 18 },
                    { 58, 4, 6, 18 },
                    { 61, 1, 1, 19 },
                    { 62, 2, 3, 19 },
                    { 63, 3, 4, 19 },
                    { 64, 4, 6, 19 },
                    { 67, 1, 1, 21 },
                    { 68, 2, 3, 21 },
                    { 69, 3, 4, 21 },
                    { 70, 4, 6, 21 },
                    { 79, 1, 1, 11 },
                    { 80, 2, 3, 11 },
                    { 85, 1, 1, 8 },
                    { 86, 2, 3, 8 },
                    { 88, 1, 1, 7 },
                    { 89, 2, 3, 7 },
                    { 91, 1, 1, 5 },
                    { 92, 2, 3, 5 },
                    { 94, 1, 1, 2 },
                    { 95, 2, 3, 2 },
                    { 97, 3, 5, 14 }
                });

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

            migrationBuilder.InsertData(
                schema: "task",
                table: "JobTypeStatusMapping",
                columns: new[] { "ID", "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[,]
                {
                    { 11, 5, 8, 3 },
                    { 12, 6, 9, 3 },
                    { 17, 5, 8, 6 },
                    { 18, 6, 9, 6 },
                    { 23, 5, 8, 9 },
                    { 24, 6, 9, 9 },
                    { 29, 5, 8, 10 },
                    { 30, 6, 9, 10 },
                    { 35, 5, 8, 13 },
                    { 36, 6, 9, 13 },
                    { 41, 5, 8, 14 },
                    { 42, 6, 9, 14 },
                    { 47, 5, 8, 16 },
                    { 48, 6, 9, 16 },
                    { 53, 5, 8, 17 },
                    { 54, 6, 9, 17 },
                    { 59, 5, 8, 18 },
                    { 60, 6, 9, 18 },
                    { 65, 5, 8, 19 },
                    { 66, 6, 9, 19 },
                    { 71, 5, 8, 21 },
                    { 72, 6, 9, 21 },
                    { 73, 1, 1, 22 },
                    { 74, 2, 3, 22 },
                    { 75, 3, 4, 22 },
                    { 76, 4, 6, 22 },
                    { 77, 5, 8, 22 },
                    { 78, 6, 9, 22 },
                    { 81, 3, 9, 11 },
                    { 82, 1, 1, 23 },
                    { 83, 2, 3, 23 },
                    { 84, 3, 9, 23 },
                    { 87, 3, 9, 8 },
                    { 90, 3, 9, 7 },
                    { 93, 3, 9, 5 },
                    { 96, 3, 9, 2 },
                    { 98, 4, 7, 14 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 94);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 95);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 96);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 97);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 98);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 9);

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

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 47, 53, 618, DateTimeKind.Local).AddTicks(5536), new DateTime(2026, 4, 17, 10, 47, 53, 620, DateTimeKind.Local).AddTicks(9709) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2839), new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2841) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2843), new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2856) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2857), new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2857) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2858), new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2861) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2862), new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2863) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2864), new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2866) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2867), new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2868) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2868), new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2869) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2870), new DateTime(2026, 4, 17, 10, 47, 53, 621, DateTimeKind.Local).AddTicks(2871) });

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
                value: "On Hold");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 4,
                column: "StatusName",
                value: "Todo Later");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 5,
                column: "StatusName",
                value: "Payment made for invoice");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobStatusMaster",
                keyColumn: "ID",
                keyValue: 6,
                column: "StatusName",
                value: "Completed");

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 1,
                column: "JobTypeId",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 6, 3 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 1, 1, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 2, 2, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 3, 3, 10 });

            migrationBuilder.UpdateData(
                schema: "task",
                table: "JobTypeStatusMapping",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "DisplayOrder", "JobStatusMasterId", "JobTypeId" },
                values: new object[] { 4, 6, 10 });

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
    }
}
