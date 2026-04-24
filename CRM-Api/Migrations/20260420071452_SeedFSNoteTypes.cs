using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedFSNoteTypes : Migration
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
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 786, DateTimeKind.Local).AddTicks(341), new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(3618) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4773), new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4776) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4778), new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4778) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4779), new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4780) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4781), new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4782) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4783), new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4783) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4785), new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4785) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4786), new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4787) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4788), new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4789) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4790), new DateTime(2026, 4, 20, 12, 44, 49, 788, DateTimeKind.Local).AddTicks(4790) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FSNoteMaster",
                columns: new[] { "ID", "CreatedDT", "CreatedUserID", "IsActive", "NoteType", "SortOrder", "UpdDT", "UpdUserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(9728), null, true, "Retained Earnings", 1, new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(9730), null },
                    { 2, new DateTime(2026, 4, 20, 12, 44, 49, 790, DateTimeKind.Local).AddTicks(583), null, true, "Common Note", 2, new DateTime(2026, 4, 20, 12, 44, 49, 790, DateTimeKind.Local).AddTicks(585), null }
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8358), new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8362) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8965), new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8967) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8968), new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8969) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8970), new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8970) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8972), new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8972) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8973), new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8974) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8975), new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8975) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8976), new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8977) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8978), new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8979) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8980), new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(8980) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 979, DateTimeKind.Local).AddTicks(8486), new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(2133) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3809), new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3811) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3814), new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3814) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3815), new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3816) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3817), new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3818) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3819), new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3819) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3820), new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3820) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3821), new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3828) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3829), new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3829) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3830), new DateTime(2026, 4, 20, 12, 42, 59, 983, DateTimeKind.Local).AddTicks(3831) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(8474), new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(8477) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9102), new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9105) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9107), new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9107) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9108), new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9109) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9110), new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9111) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9112), new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9112) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9113), new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9114) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9115), new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9116) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9117), new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9117) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9118), new DateTime(2026, 4, 20, 12, 42, 59, 984, DateTimeKind.Local).AddTicks(9119) });
        }
    }
}
