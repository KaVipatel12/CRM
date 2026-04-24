using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddDisplayTypeIdsToDynamicFieldMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayTypeIds",
                schema: "dbo",
                table: "DynamicFieldMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 594, DateTimeKind.Local).AddTicks(208), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(5196) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(6996), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(6998) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7001), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7002) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7003), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7003) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7005), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7005) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7006), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7007) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7008), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7008) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7009), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7010) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7014), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7015) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7016), new DateTime(2026, 4, 21, 18, 25, 40, 595, DateTimeKind.Local).AddTicks(7017) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(986), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(989) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(1919), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(1921) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(2827), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(2830) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5316), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5318) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5323), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5323) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5326), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5326) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5330), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5330) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5332), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5332) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5334), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5335) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5349), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5349) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5351), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5352) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5353), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5354) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5356), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5357) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5359), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5359) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5390), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5390) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5392), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5393) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5395), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5396) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5398), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5398) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5400), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5401) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5402), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5403) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5405), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5405) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5407), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5408) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5409), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5410) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5412), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5412) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5418), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5419) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5420), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5421) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5719), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5721) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5725), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5725) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5727), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5728) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5730), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5731) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 29,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5733), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5733) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 30,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5735), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(5736) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 597, DateTimeKind.Local).AddTicks(9420), new DateTime(2026, 4, 21, 18, 25, 40, 597, DateTimeKind.Local).AddTicks(9441) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(113), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(115) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(117), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(118) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(119), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(119) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(120), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(121) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(122), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(122) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(124), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(125), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(126) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(127), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(127) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(179), new DateTime(2026, 4, 21, 18, 25, 40, 598, DateTimeKind.Local).AddTicks(180) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayTypeIds",
                schema: "dbo",
                table: "DynamicFieldMasters");

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
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(5774), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(5776) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8214), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8217) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8221), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8221) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8226), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8227) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8229), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8229) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8232), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8233) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8235), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8236) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8238), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8239) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8241), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8241) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8244), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8244) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8246), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8247) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8248), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8249) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8276), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8277) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8279), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8279) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8282), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8282) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8284), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8284) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8286), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8287) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8354), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8354) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8356), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8357) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8359), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8359) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8361), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8361) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8363), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8364) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8366), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8366) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8368), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8368) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8686), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8688) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8691), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8691) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8699), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8699) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8701), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8702) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 29,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8704), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8704) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 30,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8706), new DateTime(2026, 4, 21, 15, 9, 35, 628, DateTimeKind.Local).AddTicks(8707) });

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
    }
}
