using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class RefactorCustomerEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ACN",
                schema: "cust",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AccountName",
                schema: "cust",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                schema: "cust",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AnnualAccountsMonth",
                schema: "cust",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BSB",
                schema: "cust",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessBankAccount",
                schema: "cust",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessCreditCardAccount",
                schema: "cust",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessLoanAccount",
                schema: "cust",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessName",
                schema: "cust",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ChargeInterest",
                schema: "cust",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ChargeMonthlyDisbursement",
                schema: "cust",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DirectorID",
                schema: "cust",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "GroupName",
                schema: "cust",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Salutation",
                schema: "cust",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "BusinessName",
                schema: "cust",
                table: "CustomerSolePropriterInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DirectorID",
                schema: "cust",
                table: "CustomerSolePropriterInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DirectorID",
                schema: "cust",
                table: "CustomerIndividualInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 724, DateTimeKind.Local).AddTicks(5250));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5389));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5407));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5408));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5410));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5411));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5412));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5413));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 14, 12, 4, 727, DateTimeKind.Local).AddTicks(5414));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessName",
                schema: "cust",
                table: "CustomerSolePropriterInfo");

            migrationBuilder.DropColumn(
                name: "DirectorID",
                schema: "cust",
                table: "CustomerSolePropriterInfo");

            migrationBuilder.DropColumn(
                name: "DirectorID",
                schema: "cust",
                table: "CustomerIndividualInfo");

            migrationBuilder.AddColumn<string>(
                name: "ACN",
                schema: "cust",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                schema: "cust",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AccountNumber",
                schema: "cust",
                table: "Customers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnnualAccountsMonth",
                schema: "cust",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BSB",
                schema: "cust",
                table: "Customers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessBankAccount",
                schema: "cust",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessCreditCardAccount",
                schema: "cust",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessLoanAccount",
                schema: "cust",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessName",
                schema: "cust",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ChargeInterest",
                schema: "cust",
                table: "Customers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ChargeMonthlyDisbursement",
                schema: "cust",
                table: "Customers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DirectorID",
                schema: "cust",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                schema: "cust",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salutation",
                schema: "cust",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 11, 6, 59, 686, DateTimeKind.Local).AddTicks(2554));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 11, 6, 59, 689, DateTimeKind.Local).AddTicks(7790));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 11, 6, 59, 689, DateTimeKind.Local).AddTicks(8846));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 11, 6, 59, 689, DateTimeKind.Local).AddTicks(8853));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 11, 6, 59, 689, DateTimeKind.Local).AddTicks(8855));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 11, 6, 59, 689, DateTimeKind.Local).AddTicks(8856));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 11, 6, 59, 689, DateTimeKind.Local).AddTicks(8858));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 11, 6, 59, 689, DateTimeKind.Local).AddTicks(8859));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 11, 6, 59, 689, DateTimeKind.Local).AddTicks(8860));

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                column: "UpdDT",
                value: new DateTime(2026, 4, 7, 11, 6, 59, 689, DateTimeKind.Local).AddTicks(8861));
        }
    }
}
