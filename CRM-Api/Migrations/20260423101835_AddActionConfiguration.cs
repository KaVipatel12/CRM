using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddActionConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionConfiguration",
                schema: "setting",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMTPPort = table.Column<int>(type: "int", nullable: true),
                    SMTPHost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCEmail1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCEmail2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    PasswordManagerPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionConfiguration", x => x.ID);
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 118, DateTimeKind.Local).AddTicks(9034), new DateTime(2026, 4, 23, 15, 48, 33, 151, DateTimeKind.Local).AddTicks(7376) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(765), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(769) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(774), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(774) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(776), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(776) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(777), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(777) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(778), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(780) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(781), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(781) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(782), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(782) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(784), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(950) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(957), new DateTime(2026, 4, 23, 15, 48, 33, 152, DateTimeKind.Local).AddTicks(957) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(5320), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(5323) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(6434), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(6436) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(7439), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(7442) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9941), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9944) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9948), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9949) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9951), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9952) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9954), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9954) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9957), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9958) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9961), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9961) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9964), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9964) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9966), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9967) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9969), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9970) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9972), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9972) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9984), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(9984) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(27), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(27) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(30), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(30) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(33), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(33) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(35), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(36) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(37), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(38) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(40), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(40) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(43), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(44) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(45), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(46) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(48), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(48) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(198), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(199) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(202), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(203) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(205), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(206) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(543), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(549), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(549) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(552), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(553) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(556), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(556) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 29,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(558), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(559) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 30,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(561), new DateTime(2026, 4, 23, 15, 48, 33, 165, DateTimeKind.Local).AddTicks(562) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3112), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3125) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3910), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3912) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3915), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3916) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3917), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3918) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3919), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3919) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3920), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3921) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3922), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3923) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3924), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3925) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3926), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3926) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3984), new DateTime(2026, 4, 23, 15, 48, 33, 164, DateTimeKind.Local).AddTicks(3984) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionConfiguration",
                schema: "setting");

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 517, DateTimeKind.Local).AddTicks(9006), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(1493) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2872), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2874) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2878), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2878) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2879), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2880) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2881), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2882) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2883), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2884) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2885), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2886) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2887), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2888) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2889), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2889) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2890), new DateTime(2026, 4, 23, 15, 40, 7, 519, DateTimeKind.Local).AddTicks(2890) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(9374), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(9377) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(365), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(367) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(1319), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(1323) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3735), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3737) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3741), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3741) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3744), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3744) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3746), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3747) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3748), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3749) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3751), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3751) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3753), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3753) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3755), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3756) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3757), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3758) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3760), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3760) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3762), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3762) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3797), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3798) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3800), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3800) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3802), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3803) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3804), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3805) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3814), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3815) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3817), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3817) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3820), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3820) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3823), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3823) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3826), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3827) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3829), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3829) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3831), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3832) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3834), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(3834) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4162), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4164) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4168), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4168) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4170), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4171) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4173), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4174) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 29,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4176), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4176) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "FormMaster",
                keyColumn: "ID",
                keyValue: 30,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4178), new DateTime(2026, 4, 23, 15, 40, 7, 521, DateTimeKind.Local).AddTicks(4179) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(7805), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(7810) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8503), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8505) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8507), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8507) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8509), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8509) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8510), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8511) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8512), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8512) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8513), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8514) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8515), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8515) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8517), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8517) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8556), new DateTime(2026, 4, 23, 15, 40, 7, 520, DateTimeKind.Local).AddTicks(8556) });
        }
    }
}
