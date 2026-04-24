using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCreationAuditFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Delayed drop of legacy columns to allow data transfer first

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDT",
                schema: "task",
                table: "JobTask",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserID",
                schema: "task",
                table: "JobTask",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDT",
                schema: "task",
                table: "JobHistory",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserID",
                schema: "task",
                table: "JobHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDT",
                schema: "task",
                table: "JobComment",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserID",
                schema: "task",
                table: "JobComment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDT",
                schema: "task",
                table: "Job",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserID",
                schema: "task",
                table: "Job",
                type: "int",
                nullable: true);

            // --- ZERO DATA LOSS DATA MIGRATION ---
            migrationBuilder.Sql("UPDATE task.Job SET CreatedDT = CreatedDate");
            migrationBuilder.Sql("UPDATE task.JobTask SET CreatedDT = CreatedDate");
            migrationBuilder.Sql("UPDATE task.JobComment SET CreatedDT = CreatedAt");

            // --- NOW WE CAN SAFELY DROP THE LEGACY COLUMNS ---
            migrationBuilder.DropColumn(name: "CreatedDate", schema: "task", table: "JobTask");
            migrationBuilder.DropColumn(name: "CreatedAt", schema: "task", table: "JobComment");
            migrationBuilder.DropColumn(name: "CreatedDate", schema: "task", table: "Job");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDT",
                schema: "file",
                table: "FileUploadInfo",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserID",
                schema: "file",
                table: "FileUploadInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDT",
                schema: "cust",
                table: "EntityType",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserID",
                schema: "cust",
                table: "EntityType",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDT",
                schema: "cust",
                table: "CustomerType",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserID",
                schema: "cust",
                table: "CustomerType",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDT",
                schema: "cust",
                table: "CustomerTrustInfo",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserID",
                schema: "cust",
                table: "CustomerTrustInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDT",
                schema: "cust",
                table: "CustomerSolePropriterInfo",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserID",
                schema: "cust",
                table: "CustomerSolePropriterInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDT",
                schema: "cust",
                table: "Customers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserID",
                schema: "cust",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDT",
                schema: "cust",
                table: "CustomerIndividualInfo",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserID",
                schema: "cust",
                table: "CustomerIndividualInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDT",
                schema: "cust",
                table: "CustomerCompanyInfo",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserID",
                schema: "cust",
                table: "CustomerCompanyInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDT",
                schema: "cust",
                table: "ContactInfo",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserID",
                schema: "cust",
                table: "ContactInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDT",
                schema: "cust",
                table: "Branch",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserID",
                schema: "cust",
                table: "Branch",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDT",
                schema: "cust",
                table: "BankAccount",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserID",
                schema: "cust",
                table: "BankAccount",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDT",
                schema: "cust",
                table: "Address",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserID",
                schema: "cust",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "CreatedUserID", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 251, DateTimeKind.Local).AddTicks(8259), null, new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(4544) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "CreatedUserID", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6192), null, new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6196) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "CreatedUserID", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6199), null, new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6199) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "CreatedUserID", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6200), null, new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6201) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "CreatedUserID", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6202), null, new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6203) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "CreatedUserID", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6204), null, new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6204) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "CreatedUserID", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6206), null, new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6206) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "CreatedUserID", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6207), null, new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6208) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "CreatedUserID", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6208), null, new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6209) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "CreatedUserID", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6210), null, new DateTime(2026, 4, 13, 15, 17, 14, 254, DateTimeKind.Local).AddTicks(6210) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDT",
                schema: "task",
                table: "JobTask");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "task",
                table: "JobTask");

            migrationBuilder.DropColumn(
                name: "CreatedDT",
                schema: "task",
                table: "JobHistory");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "task",
                table: "JobHistory");

            migrationBuilder.DropColumn(
                name: "CreatedDT",
                schema: "task",
                table: "JobComment");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "task",
                table: "JobComment");

            migrationBuilder.DropColumn(
                name: "CreatedDT",
                schema: "task",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "task",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "CreatedDT",
                schema: "file",
                table: "FileUploadInfo");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "file",
                table: "FileUploadInfo");

            migrationBuilder.DropColumn(
                name: "CreatedDT",
                schema: "cust",
                table: "EntityType");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "cust",
                table: "EntityType");

            migrationBuilder.DropColumn(
                name: "CreatedDT",
                schema: "cust",
                table: "CustomerType");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "cust",
                table: "CustomerType");

            migrationBuilder.DropColumn(
                name: "CreatedDT",
                schema: "cust",
                table: "CustomerTrustInfo");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "cust",
                table: "CustomerTrustInfo");

            migrationBuilder.DropColumn(
                name: "CreatedDT",
                schema: "cust",
                table: "CustomerSolePropriterInfo");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "cust",
                table: "CustomerSolePropriterInfo");

            migrationBuilder.DropColumn(
                name: "CreatedDT",
                schema: "cust",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "cust",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedDT",
                schema: "cust",
                table: "CustomerIndividualInfo");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "cust",
                table: "CustomerIndividualInfo");

            migrationBuilder.DropColumn(
                name: "CreatedDT",
                schema: "cust",
                table: "CustomerCompanyInfo");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "cust",
                table: "CustomerCompanyInfo");

            migrationBuilder.DropColumn(
                name: "CreatedDT",
                schema: "cust",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "cust",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "CreatedDT",
                schema: "cust",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "cust",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "CreatedDT",
                schema: "cust",
                table: "BankAccount");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "cust",
                table: "BankAccount");

            migrationBuilder.DropColumn(
                name: "CreatedDT",
                schema: "cust",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "cust",
                table: "Address");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "task",
                table: "JobTask",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "task",
                table: "JobComment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "task",
                table: "Job",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                column: "UpdDT",
                value: new DateTime(2026, 4, 13, 12, 10, 7, 168, DateTimeKind.Local).AddTicks(2893));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                column: "UpdDT",
                value: new DateTime(2026, 4, 13, 12, 10, 7, 170, DateTimeKind.Local).AddTicks(9132));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                column: "UpdDT",
                value: new DateTime(2026, 4, 13, 12, 10, 7, 170, DateTimeKind.Local).AddTicks(9167));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                column: "UpdDT",
                value: new DateTime(2026, 4, 13, 12, 10, 7, 170, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                column: "UpdDT",
                value: new DateTime(2026, 4, 13, 12, 10, 7, 170, DateTimeKind.Local).AddTicks(9171));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                column: "UpdDT",
                value: new DateTime(2026, 4, 13, 12, 10, 7, 170, DateTimeKind.Local).AddTicks(9172));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                column: "UpdDT",
                value: new DateTime(2026, 4, 13, 12, 10, 7, 170, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                column: "UpdDT",
                value: new DateTime(2026, 4, 13, 12, 10, 7, 170, DateTimeKind.Local).AddTicks(9174));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                column: "UpdDT",
                value: new DateTime(2026, 4, 13, 12, 10, 7, 170, DateTimeKind.Local).AddTicks(9175));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                column: "UpdDT",
                value: new DateTime(2026, 4, 13, 12, 10, 7, 170, DateTimeKind.Local).AddTicks(9176));
        }
    }
}
