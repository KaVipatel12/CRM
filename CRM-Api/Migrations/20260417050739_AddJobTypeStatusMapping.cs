using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddJobTypeStatusMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRelationships_Customers_SourceCustomerId",
                schema: "cust",
                table: "CustomerRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRelationships_Customers_TargetCustomerId",
                schema: "cust",
                table: "CustomerRelationships");

            migrationBuilder.CreateTable(
                name: "JobTypeStatusMapping",
                schema: "task",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTypeID = table.Column<int>(type: "int", nullable: false),
                    JobStatusMasterID = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypeStatusMapping", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JobTypeStatusMapping_JobStatusMaster_JobStatusMasterID",
                        column: x => x.JobStatusMasterID,
                        principalSchema: "task",
                        principalTable: "JobStatusMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobTypeStatusMapping_TypeMaster_JobTypeID",
                        column: x => x.JobTypeID,
                        principalSchema: "task",
                        principalTable: "TypeMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 37, 31, 733, DateTimeKind.Local).AddTicks(6005), new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(4504) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(7751), new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(7756) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(7759), new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(7759) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(7760), new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(7762) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(7763), new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(7764) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(7765), new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(7765) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(7767), new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(7767) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(7768), new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(7769) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(7999), new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(7999) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(8000), new DateTime(2026, 4, 17, 10, 37, 31, 736, DateTimeKind.Local).AddTicks(8001) });

            migrationBuilder.InsertData(
                schema: "task",
                table: "JobTypeStatusMapping",
                columns: new[] { "ID", "DisplayOrder", "JobStatusMasterID", "JobTypeID" },
                values: new object[,]
                {
                    { 1, 1, 1, 3 },
                    { 2, 2, 2, 3 },
                    { 3, 3, 6, 3 },
                    { 4, 1, 1, 10 },
                    { 5, 2, 2, 10 },
                    { 6, 3, 3, 10 },
                    { 7, 4, 6, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobTypeStatusMapping_JobStatusMasterID",
                schema: "task",
                table: "JobTypeStatusMapping",
                column: "JobStatusMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_JobTypeStatusMapping_JobTypeID",
                schema: "task",
                table: "JobTypeStatusMapping",
                column: "JobTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRelationships_Customers_SourceCustomerId",
                schema: "cust",
                table: "CustomerRelationships",
                column: "SourceCustomerId",
                principalSchema: "cust",
                principalTable: "Customers",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRelationships_Customers_TargetCustomerId",
                schema: "cust",
                table: "CustomerRelationships",
                column: "TargetCustomerId",
                principalSchema: "cust",
                principalTable: "Customers",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRelationships_Customers_SourceCustomerId",
                schema: "cust",
                table: "CustomerRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRelationships_Customers_TargetCustomerId",
                schema: "cust",
                table: "CustomerRelationships");

            migrationBuilder.DropTable(
                name: "JobTypeStatusMapping",
                schema: "task");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 297, DateTimeKind.Local).AddTicks(8675), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(954) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2284), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2286) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2287), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2288) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2289), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2289) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2290), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2291) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2292), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2292) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2293), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2293) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2295), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2295) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2296), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2297) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2297), new DateTime(2026, 4, 14, 18, 23, 50, 299, DateTimeKind.Local).AddTicks(2298) });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRelationships_Customers_SourceCustomerId",
                schema: "cust",
                table: "CustomerRelationships",
                column: "SourceCustomerId",
                principalSchema: "cust",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRelationships_Customers_TargetCustomerId",
                schema: "cust",
                table: "CustomerRelationships",
                column: "TargetCustomerId",
                principalSchema: "cust",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
