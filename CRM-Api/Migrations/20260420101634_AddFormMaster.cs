using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddFormMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormMaster",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AllowPdf = table.Column<bool>(type: "bit", nullable: false),
                    AllowEmail = table.Column<bool>(type: "bit", nullable: false),
                    AllowView = table.Column<bool>(type: "bit", nullable: false),
                    AllowDownload = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormMaster", x => x.ID);
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 695, DateTimeKind.Local).AddTicks(7776), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(1678) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2767), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2769) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2771), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2771) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2772), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2773) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2843), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2843) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2844), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2845) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2846), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2847) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2848), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2848) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2849), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2850) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2851), new DateTime(2026, 4, 20, 15, 46, 30, 697, DateTimeKind.Local).AddTicks(2851) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(7262), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(7264) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(8080), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(8082) });

            migrationBuilder.InsertData(
                schema: "cust",
                table: "FormMaster",
                columns: new[] { "ID", "AllowDownload", "AllowEmail", "AllowPdf", "AllowView", "Category", "CreatedDT", "CreatedUserID", "DisplayOrder", "Icon", "IsActive", "Name", "Slug", "UpdDT", "UpdUserID" },
                values: new object[,]
                {
                    { 1, false, true, true, true, "Tax", new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(8870), null, 1, "heroicons_outline:document-text", true, "Individual Tax Return", "individual-tax-return", new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(8873), null },
                    { 2, false, false, true, true, "Checklist", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(834), null, 2, "heroicons_outline:clipboard-list", true, "BAS Bookkeeping Checklist", "bas-bookkeeping-checklist", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(836), null },
                    { 3, false, false, true, true, "Checklist", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(875), null, 3, "heroicons_outline:clipboard-list", true, "BAS Lodgment Checklist", "bas-lodgment-checklist", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(875), null },
                    { 4, false, false, true, true, "Tax", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(877), null, 4, "heroicons_outline:document-text", true, "Tax Return Partnership", "tax-return-partnership", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(878), null },
                    { 5, false, false, true, true, "Tax", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(880), null, 5, "heroicons_outline:document-text", true, "Tax Return Company", "tax-return-company", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(880), null },
                    { 6, false, true, true, true, "Registration", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(882), null, 6, "heroicons_outline:briefcase", true, "Business Registration", "business-registration", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(882), null },
                    { 7, false, true, true, true, "Accounts", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(884), null, 7, "heroicons_outline:calculator", true, "Bookkeeping Set", "bookkeeping-set", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(884), null },
                    { 8, false, true, true, true, "HR", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(886), null, 8, "heroicons_outline:user", true, "Employee Details", "employee-details", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(886), null },
                    { 9, false, true, true, true, "General", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(888), null, 9, "heroicons_outline:question-mark-circle", true, "Inquiry form", "inquiry-form", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(889), null },
                    { 10, false, true, true, true, "General", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(890), null, 10, "heroicons_outline:user-add", true, "Client Enrollment", "client-enrollment", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(891), null },
                    { 11, false, true, true, true, "Tax", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(892), null, 11, "heroicons_outline:home", true, "Rental Property", "rental-property", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(893), null },
                    { 12, false, true, true, true, "General", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(895), null, 12, "heroicons_outline:refresh", true, "Update Client Details", "update-client-details", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(895), null },
                    { 13, false, true, true, true, "Finance", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(907), null, 13, "heroicons_outline:cash", true, "SuperAnnuation Claim", "superannuation-claim", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(907), null },
                    { 14, false, true, false, true, "Checklist", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(909), null, 14, "heroicons_outline:clock", true, "BAS Reminder", "bas-reminder", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(910), null },
                    { 15, false, true, false, true, "General", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(911), null, 15, "heroicons_outline:speakerphone", true, "Announcement", "announcement", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(912), null },
                    { 16, false, true, true, true, "Finance", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(914), null, 16, "heroicons_outline:chart-pie", true, "Investment Client Form", "investment-client-form", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(914), null },
                    { 17, false, true, true, true, "HR", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(918), null, 17, "heroicons_outline:user-group", true, "Employee Details (For SSP Staff only)", "employee-details-staff", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(918), null },
                    { 18, false, false, true, true, "General", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(920), null, 18, "heroicons_outline:phone", true, "Call Tracker", "call-tracker", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(920), null },
                    { 19, false, false, true, true, "General", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(922), null, 19, "heroicons_outline:calendar", true, "Daily Diary", "daily-diary", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(922), null },
                    { 20, false, false, false, true, "General", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(924), null, 20, "heroicons_outline:external-link", true, "JatForm", "jatform", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(924), null },
                    { 21, false, false, false, true, "External", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(926), null, 21, "heroicons_outline:calculator", true, "Commonwealth Bank Home Loan Calculators", "cba-home-loan-calc", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(927), null },
                    { 22, false, false, false, true, "External", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(928), null, 22, "heroicons_outline:calculator", true, "Pay Calculator Australia", "pay-calc-au", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(929), null },
                    { 23, false, true, true, true, "Finance", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(931), null, 23, "heroicons_outline:home", true, "Home Loan Application", "home-loan-application", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(931), null },
                    { 24, true, false, false, true, "Finance", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(933), null, 24, "heroicons_outline:download", true, "Authority DASP", "authority-dasp", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(933), null },
                    { 25, true, false, false, true, "Templates", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1217), null, 25, "heroicons_outline:mail", true, "Letterhead", "letterhead", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1219), null },
                    { 26, true, false, false, true, "Templates", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1222), null, 26, "heroicons_outline:mail", true, "Sukhwinder Letterhead", "letterhead-sukhwinder", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1222), null },
                    { 27, true, false, false, true, "Templates", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1224), null, 27, "heroicons_outline:mail", true, "Letterhead SSP2 - Gaurav Mittal", "letterhead-gaurav", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1224), null },
                    { 28, true, false, false, true, "Templates", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1226), null, 28, "heroicons_outline:mail", true, "Letterhead SSP2 - Napa Arinaphat", "letterhead-napa", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1227), null },
                    { 29, true, false, false, true, "Templates", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1228), null, 29, "heroicons_outline:mail", true, "Don't Tell Tiger Letterhead - Napa", "letterhead-tiger-napa", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1229), null },
                    { 30, true, false, false, true, "Templates", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1231), null, 30, "heroicons_outline:mail", true, "Don't Tell Tiger Letterhead - Sukhwinder", "letterhead-tiger-sukhwinder", new DateTime(2026, 4, 20, 15, 46, 30, 699, DateTimeKind.Local).AddTicks(1231), null }
                });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(5660), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(5663) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6477), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6479) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6481), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6481) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6483), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6483) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6484), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6485) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6486), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6486) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6487), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6488) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6489), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6489) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6490), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6490) });

            migrationBuilder.UpdateData(
                schema: "cust",
                table: "ServiceMaster",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6492), new DateTime(2026, 4, 20, 15, 46, 30, 698, DateTimeKind.Local).AddTicks(6492) });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFSNote_CreatedUserID",
                schema: "cust",
                table: "CustomerFSNote",
                column: "CreatedUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerFSNote_AspNetUsers_CreatedUserID",
                schema: "cust",
                table: "CustomerFSNote",
                column: "CreatedUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFSNote_AspNetUsers_CreatedUserID",
                schema: "cust",
                table: "CustomerFSNote");

            migrationBuilder.DropTable(
                name: "FormMaster",
                schema: "cust");

            migrationBuilder.DropIndex(
                name: "IX_CustomerFSNote_CreatedUserID",
                schema: "cust",
                table: "CustomerFSNote");

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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(9728), new DateTime(2026, 4, 20, 12, 44, 49, 789, DateTimeKind.Local).AddTicks(9730) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FSNoteMaster",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDT", "UpdDT" },
                values: new object[] { new DateTime(2026, 4, 20, 12, 44, 49, 790, DateTimeKind.Local).AddTicks(583), new DateTime(2026, 4, 20, 12, 44, 49, 790, DateTimeKind.Local).AddTicks(585) });

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
    }
}
