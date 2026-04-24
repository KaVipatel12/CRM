using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class FixCasingForJobStatusMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTypeStatusMapping_JobStatusMaster_JobStatusMasterID",
                schema: "task",
                table: "JobTypeStatusMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTypeStatusMapping_TypeMaster_JobTypeID",
                schema: "task",
                table: "JobTypeStatusMapping");

            migrationBuilder.RenameColumn(
                name: "JobTypeID",
                schema: "task",
                table: "JobTypeStatusMapping",
                newName: "JobTypeId");

            migrationBuilder.RenameColumn(
                name: "JobStatusMasterID",
                schema: "task",
                table: "JobTypeStatusMapping",
                newName: "JobStatusMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_JobTypeStatusMapping_JobTypeID",
                schema: "task",
                table: "JobTypeStatusMapping",
                newName: "IX_JobTypeStatusMapping_JobTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_JobTypeStatusMapping_JobStatusMasterID",
                schema: "task",
                table: "JobTypeStatusMapping",
                newName: "IX_JobTypeStatusMapping_JobStatusMasterId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_JobTypeStatusMapping_JobStatusMaster_JobStatusMasterId",
                schema: "task",
                table: "JobTypeStatusMapping",
                column: "JobStatusMasterId",
                principalSchema: "task",
                principalTable: "JobStatusMaster",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTypeStatusMapping_TypeMaster_JobTypeId",
                schema: "task",
                table: "JobTypeStatusMapping",
                column: "JobTypeId",
                principalSchema: "task",
                principalTable: "TypeMaster",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTypeStatusMapping_JobStatusMaster_JobStatusMasterId",
                schema: "task",
                table: "JobTypeStatusMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTypeStatusMapping_TypeMaster_JobTypeId",
                schema: "task",
                table: "JobTypeStatusMapping");

            migrationBuilder.RenameColumn(
                name: "JobTypeId",
                schema: "task",
                table: "JobTypeStatusMapping",
                newName: "JobTypeID");

            migrationBuilder.RenameColumn(
                name: "JobStatusMasterId",
                schema: "task",
                table: "JobTypeStatusMapping",
                newName: "JobStatusMasterID");

            migrationBuilder.RenameIndex(
                name: "IX_JobTypeStatusMapping_JobTypeId",
                schema: "task",
                table: "JobTypeStatusMapping",
                newName: "IX_JobTypeStatusMapping_JobTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_JobTypeStatusMapping_JobStatusMasterId",
                schema: "task",
                table: "JobTypeStatusMapping",
                newName: "IX_JobTypeStatusMapping_JobStatusMasterID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_JobTypeStatusMapping_JobStatusMaster_JobStatusMasterID",
                schema: "task",
                table: "JobTypeStatusMapping",
                column: "JobStatusMasterID",
                principalSchema: "task",
                principalTable: "JobStatusMaster",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTypeStatusMapping_TypeMaster_JobTypeID",
                schema: "task",
                table: "JobTypeStatusMapping",
                column: "JobTypeID",
                principalSchema: "task",
                principalTable: "TypeMaster",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
