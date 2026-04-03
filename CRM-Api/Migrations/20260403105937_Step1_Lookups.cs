using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class Step1_Lookups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cust");

            migrationBuilder.CreateTable(
                name: "ContactType",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RelationShipType",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationShipType", x => x.ID);
                });

            migrationBuilder.InsertData(
                schema: "cust",
                table: "ContactType",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Client" },
                    { 2, "Prospect" },
                    { 3, "Lead" },
                    { 4, "Supplier" },
                    { 5, "Other" }
                });

            migrationBuilder.InsertData(
                schema: "cust",
                table: "RelationShipType",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Associate" },
                    { 2, "Banker" },
                    { 3, "Bookkeeper" },
                    { 4, "Director" },
                    { 5, "Lawyer" },
                    { 6, "Owner" },
                    { 7, "Professional advisor" },
                    { 8, "Partner" },
                    { 9, "Secretary" },
                    { 10, "Shareholder" },
                    { 11, "Subsidiary" },
                    { 12, "Trustee" },
                    { 13, "Beneficiary" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactType",
                schema: "cust");

            migrationBuilder.DropTable(
                name: "RelationShipType",
                schema: "cust");
        }
    }
}
