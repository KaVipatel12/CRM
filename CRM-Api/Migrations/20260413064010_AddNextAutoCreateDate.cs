using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddNextAutoCreateDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NextAutoCreateDate",
                schema: "task",
                table: "Job",
                type: "datetime2",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Job_ParentJobId",
                schema: "task",
                table: "Job",
                column: "ParentJobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Job_ParentJobId",
                schema: "task",
                table: "Job",
                column: "ParentJobId",
                principalSchema: "task",
                principalTable: "Job",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Job_ParentJobId",
                schema: "task",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_ParentJobId",
                schema: "task",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "NextAutoCreateDate",
                schema: "task",
                table: "Job");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 51, 36, 504, DateTimeKind.Local).AddTicks(4589));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 51, 36, 506, DateTimeKind.Local).AddTicks(3569));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 51, 36, 506, DateTimeKind.Local).AddTicks(3594));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 51, 36, 506, DateTimeKind.Local).AddTicks(3596));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 51, 36, 506, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 51, 36, 506, DateTimeKind.Local).AddTicks(3598));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 51, 36, 506, DateTimeKind.Local).AddTicks(3636));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 51, 36, 506, DateTimeKind.Local).AddTicks(3637));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 51, 36, 506, DateTimeKind.Local).AddTicks(3639));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                column: "UpdDT",
                value: new DateTime(2026, 4, 8, 19, 51, 36, 506, DateTimeKind.Local).AddTicks(3640));
        }
    }
}
