using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminChecklist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChecklistMaster",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApplicableClientType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerChecklistStatus",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    ChecklistMasterID = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CompletedDT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CompletedByUserID = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerChecklistStatus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerChecklistStatus_AspNetUsers_CompletedByUserID",
                        column: x => x.CompletedByUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerChecklistStatus_ChecklistMaster_ChecklistMasterID",
                        column: x => x.ChecklistMasterID,
                        principalSchema: "dbo",
                        principalTable: "ChecklistMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerChecklistStatus_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "cust",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CustomerChecklistStatus_ChecklistMasterID",
                schema: "cust",
                table: "CustomerChecklistStatus",
                column: "ChecklistMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerChecklistStatus_CompletedByUserID",
                schema: "cust",
                table: "CustomerChecklistStatus",
                column: "CompletedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerChecklistStatus_CustomerID",
                schema: "cust",
                table: "CustomerChecklistStatus",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerChecklistStatus",
                schema: "cust");

            migrationBuilder.DropTable(
                name: "ChecklistMaster",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 413, DateTimeKind.Local).AddTicks(3642), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(51) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1750), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1753) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1755), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1755) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1757), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1757) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1758), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1759) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1760), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1760) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1761), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1762) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1765), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1765) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1766), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1767) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1768), new DateTime(2026, 4, 17, 18, 42, 48, 416, DateTimeKind.Local).AddTicks(1769) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5123), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5127) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5722), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5725) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5727), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5727) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5728), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5729) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5730), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5730) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5731), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5732) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5733), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5733) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5735), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5735) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5736), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5737) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5738), new DateTime(2026, 4, 17, 18, 42, 48, 417, DateTimeKind.Local).AddTicks(5738) });
        }
    }
}
