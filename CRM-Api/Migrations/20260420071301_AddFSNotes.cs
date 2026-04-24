using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddFSNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FSNoteMaster",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FSNoteMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFSNote",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    FSNoteMasterID = table.Column<int>(type: "int", nullable: false),
                    NoteContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFSNote", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerFSNote_AspNetUsers_UpdUserID",
                        column: x => x.UpdUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerFSNote_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "cust",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerFSNote_FSNoteMaster_FSNoteMasterID",
                        column: x => x.FSNoteMasterID,
                        principalSchema: "dbo",
                        principalTable: "FSNoteMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFSNote_CustomerID",
                schema: "cust",
                table: "CustomerFSNote",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFSNote_FSNoteMasterID",
                schema: "cust",
                table: "CustomerFSNote",
                column: "FSNoteMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFSNote_UpdUserID",
                schema: "cust",
                table: "CustomerFSNote",
                column: "UpdUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerFSNote",
                schema: "cust");

            migrationBuilder.DropTable(
                name: "FSNoteMaster",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 565, DateTimeKind.Local).AddTicks(7714), new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(1178) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2470), new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2472) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2473), new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2484) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2484), new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2485) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2486), new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2486) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2487), new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2487) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2488), new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2490) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2490), new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2491) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2492), new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2492) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2493), new DateTime(2026, 4, 20, 10, 55, 54, 567, DateTimeKind.Local).AddTicks(2493) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(5755), new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(5759) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6333), new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6335) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6336), new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6337) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6338), new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6338) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6339), new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6340) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6341), new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6341) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6343), new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6343) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6345), new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6345) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6347), new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6347) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6349), new DateTime(2026, 4, 20, 10, 55, 54, 568, DateTimeKind.Local).AddTicks(6349) });
        }
    }
}
