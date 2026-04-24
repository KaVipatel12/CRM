using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class Step4_CustomerCrud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerSolePropriterInfo",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ABNDivisionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassOfClients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FiledbyFirm = table.Column<bool>(type: "bit", nullable: true),
                    ABNContractor = table.Column<bool>(type: "bit", nullable: true),
                    TitleAbbreviated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleFull = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DASP = table.Column<bool>(type: "bit", nullable: true),
                    IndividualTaxReturn = table.Column<bool>(type: "bit", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSolePropriterInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerSolePropriterInfo_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "cust",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detail_TypeID",
                schema: "task",
                table: "Detail",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSolePropriterInfo_CustomerID",
                schema: "cust",
                table: "CustomerSolePropriterInfo",
                column: "CustomerID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Detail_TypeMaster_TypeID",
                schema: "task",
                table: "Detail",
                column: "TypeID",
                principalSchema: "task",
                principalTable: "TypeMaster",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detail_TypeMaster_TypeID",
                schema: "task",
                table: "Detail");

            migrationBuilder.DropTable(
                name: "CustomerSolePropriterInfo",
                schema: "cust");

            migrationBuilder.DropIndex(
                name: "IX_Detail_TypeID",
                schema: "task",
                table: "Detail");
        }
    }
}
