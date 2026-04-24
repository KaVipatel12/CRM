using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddVisibleForClientTypesToFormMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VisibleForClientTypes",
                schema: "cust",
                table: "FormMaster",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 625, DateTimeKind.Local).AddTicks(2300), new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(7006) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8497), new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8500) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8501), new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8502) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8503), new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8503) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8507), new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8508) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8509), new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8510) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8511), new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8511) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8512), new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8513) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8514), new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8515) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8516), new DateTime(2026, 4, 21, 15, 9, 35, 626, DateTimeKind.Local).AddTicks(8517) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(4043), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(4046) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(4909), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(4912) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(5774), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(5776), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8214), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8217), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8221), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8221), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8226), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8227), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8229), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8229), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8232), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8233), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8235), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8236), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8238), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8239), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8241), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8241), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8244), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8244), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8246), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8247), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8248), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8249), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8276), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8277), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8279), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8279), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8282), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8282), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8284), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8284), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8286), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8287), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8354), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8354), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8356), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8357), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8359), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8359), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8361), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8361), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8363), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8364), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8366), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8366), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8368), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8368), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8686), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8688), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8691), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8691), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8699), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8699), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8701), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8702), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 29,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8704), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8704), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 30,
                columns: new[] { "CreatedDT", "UpdDT", "VisibleForClientTypes" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8706), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8707), null });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(2621), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(2626) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3233), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3236) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3238), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3238) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3239), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3240) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3241), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3241) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3242), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3243) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3244), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3244) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3245), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3246) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3247), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3248) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3282), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(3282) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisibleForClientTypes",
                schema: "cust",
                table: "FormMaster");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 778, DateTimeKind.Local).AddTicks(5779), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(7694) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8621), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8624) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8626), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8626) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8627), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8628) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8629), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8629) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8630), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8631) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8632), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8632) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8633), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8634) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8635), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8635) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8636), new DateTime(2026, 4, 21, 12, 8, 1, 779, DateTimeKind.Local).AddTicks(8637) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(319), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(322) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(1256), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(1260) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(2174), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(2177) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5069), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5072) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5076), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5076) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5079), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5079) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5081), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5082) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5085), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5085) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5088), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5089) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5091), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5091) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5094), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5095) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5098), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5099) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5100), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5101) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5103), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5103) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5131), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5131) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5133), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5134) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5136), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5136) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5138), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5138) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5140), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5141) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5143), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5143) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5145), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5146) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5148), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5148) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5159), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5160) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5162), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5162) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5164), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5164) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5166), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5167) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5487), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5490) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5494), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5494) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5499), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5499) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5502), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5502) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 29,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5504), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5505) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 30,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5507), new DateTime(2026, 4, 21, 12, 8, 1, 783, DateTimeKind.Local).AddTicks(5507) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(8696), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(8706) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9407), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9410) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9412), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9412) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9414), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9414) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9415), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9416) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9417), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9417) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9418), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9419) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9420), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9420) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9421), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9422) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9463), new DateTime(2026, 4, 21, 12, 8, 1, 782, DateTimeKind.Local).AddTicks(9463) });
        }
    }
}
