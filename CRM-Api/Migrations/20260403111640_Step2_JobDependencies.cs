using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM_Api.Migrations
{
    /// <inheritdoc />
    public partial class Step2_JobDependencies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "task");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "cust",
                table: "RelationShipType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "cust",
                table: "ContactType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "BusinessType",
                schema: "cust",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessTypeNM = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ClientType = table.Column<int>(type: "int", nullable: false),
                    FirmType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ABNNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<long>(type: "bigint", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BSB = table.Column<long>(type: "bigint", nullable: true),
                    BalanceDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingEntity = table.Column<bool>(type: "bit", nullable: true),
                    ChargeInterest = table.Column<bool>(type: "bit", nullable: true),
                    ChargeMonthlyDisbursement = table.Column<bool>(type: "bit", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Client = table.Column<bool>(type: "bit", nullable: true),
                    ClientFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientTypeSubcategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facsimile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GSTBasis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GSTPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GSTRegistered = table.Column<bool>(type: "bit", nullable: true),
                    InBusinessSince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceDeliveryBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Partner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostNewsLetter = table.Column<bool>(type: "bit", nullable: true),
                    PrepareGST = table.Column<bool>(type: "bit", nullable: true),
                    Salutation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TFNNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxReturnType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnualAccountsMonth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnualFinancialStatements = table.Column<bool>(type: "bit", nullable: true),
                    AnnualABNTaxReturn = table.Column<bool>(type: "bit", nullable: true),
                    AnnualGSTClient = table.Column<bool>(type: "bit", nullable: true),
                    AnnualNonGST = table.Column<bool>(type: "bit", nullable: true),
                    BASA = table.Column<bool>(type: "bit", nullable: true),
                    BASQ = table.Column<bool>(type: "bit", nullable: true),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessBankAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessCreditCardAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessLoanAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrepareGroupCertificates = table.Column<bool>(type: "bit", nullable: true),
                    Lodgement = table.Column<bool>(type: "bit", nullable: true),
                    FinancialStatement = table.Column<bool>(type: "bit", nullable: true),
                    PAYGWeekly = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ContactType = table.Column<int>(type: "int", nullable: true),
                    TradingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    LastVarifiedBy = table.Column<int>(type: "int", nullable: true),
                    LastVarifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DirectorID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessType = table.Column<int>(type: "int", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: true),
                    TradingStatus = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsExcluded = table.Column<bool>(type: "bit", nullable: true),
                    StaffInCharge = table.Column<int>(type: "int", nullable: true),
                    ACN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerType",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerTypeNM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityTypeID = table.Column<int>(type: "int", nullable: true),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EntityType",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityTypeNM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JobStatusMaster",
                schema: "task",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    ShowPriority = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatusMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TaxAgent",
                schema: "cust",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxAgent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TradingStatus",
                schema: "cust",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeMaster",
                schema: "task",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Addressee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Address_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "cust",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Branch_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "cust",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfo",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Salutation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CellPhonePersonName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CellPhone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    HomePhonePersonName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HomePhone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    WorkPhonePersonName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WorkPhone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContactInfo_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "cust",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCompanyInfo",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    NoOfEmployee = table.Column<int>(type: "int", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ABVDevisionNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACNNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ASICCompanyReviewDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountingSoftware = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnualAccountsMonth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Background = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FiledbyFirm = table.Column<bool>(type: "bit", nullable: true),
                    NonResidentClient = table.Column<bool>(type: "bit", nullable: true),
                    AccountingSoftware2 = table.Column<bool>(type: "bit", nullable: true),
                    ClassOfClients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToEmailForBASReports = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuperContribution = table.Column<bool>(type: "bit", nullable: true),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCompanyInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerCompanyInfo_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "cust",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerIndividualInfo",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: true),
                    ChargeInterest = table.Column<bool>(type: "bit", nullable: true),
                    ChargeMonthlyDisbursement = table.Column<bool>(type: "bit", nullable: true),
                    BirthCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NonResidentClient = table.Column<bool>(type: "bit", nullable: true),
                    TFNDivisionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleAbbreviated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleFull = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ABNContractor = table.Column<bool>(type: "bit", nullable: true),
                    BASM = table.Column<bool>(type: "bit", nullable: true),
                    DASP = table.Column<bool>(type: "bit", nullable: true),
                    IndividualTaxReturn = table.Column<bool>(type: "bit", nullable: true),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerIndividualInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerIndividualInfo_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "cust",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTrustInfo",
                schema: "cust",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    AnnualAccountsMonth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChargeInterest = table.Column<bool>(type: "bit", nullable: true),
                    ChargeMonthlyDisbursement = table.Column<bool>(type: "bit", nullable: true),
                    FiledbyFirm = table.Column<bool>(type: "bit", nullable: true),
                    NonResidentClient = table.Column<bool>(type: "bit", nullable: true),
                    BASM = table.Column<bool>(type: "bit", nullable: true),
                    DASP = table.Column<bool>(type: "bit", nullable: true),
                    SuperContribution = table.Column<bool>(type: "bit", nullable: true),
                    SuperHardship = table.Column<bool>(type: "bit", nullable: true),
                    WorkerCompensation = table.Column<bool>(type: "bit", nullable: true),
                    UpdUserID = table.Column<int>(type: "int", nullable: true),
                    UpdDT = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTrustInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerTrustInfo_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "cust",
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "task",
                table: "JobStatusMaster",
                columns: new[] { "ID", "DisplayOrder", "ShowPriority", "StatusName" },
                values: new object[,]
                {
                    { 1, null, null, "Not Yet In" },
                    { 2, null, null, "Allocated" },
                    { 3, null, null, "Active" },
                    { 4, null, null, "Pending" },
                    { 5, null, null, "Pre-Interview" },
                    { 6, null, null, "Draft" },
                    { 7, null, null, "Interviewed" },
                    { 8, null, null, "Finalising" },
                    { 9, null, null, "Complete" }
                });

            migrationBuilder.InsertData(
                schema: "task",
                table: "TypeMaster",
                columns: new[] { "ID", "Description", "ShortCode", "Type" },
                values: new object[,]
                {
                    { 1, null, "AA", "Annual Accounts" },
                    { 2, null, "ASIC", "ASIC Updates" },
                    { 3, null, "BAS", "BAS" },
                    { 4, null, "BK", "Bookkeeping " },
                    { 5, null, "BREG", "Business Registration" },
                    { 6, null, "CTR", "Company Tax Return" },
                    { 7, null, "CRE", "CRE" },
                    { 8, null, "DASP", "DASP" },
                    { 9, null, "FBT", "FBT" },
                    { 10, null, "FS", "Financial Statement" },
                    { 11, null, "GEN", "General" },
                    { 12, null, "GRPCER", "Group Certificate" },
                    { 13, null, "GST", "GST" },
                    { 14, null, "ITR", "I Tax Return" },
                    { 15, null, "IMPWIP", "Imported WIP" },
                    { 16, null, "PTR", "Partnership Tax Return" },
                    { 17, null, "PAYGM", "PAYG MONTHLY" },
                    { 18, null, "SMSF", "SMSF" },
                    { 19, null, "SPRCON", "Super Contribution" },
                    { 20, null, "SPRSET", "SuperSetup" },
                    { 21, null, "TRA", "Tax Return Amendment" },
                    { 22, null, "WAGES", "WAGES" },
                    { 23, null, "EMAIL", "Comunication Email" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerID",
                schema: "cust",
                table: "Address",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CustomerID",
                schema: "cust",
                table: "Branch",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_CustomerID",
                schema: "cust",
                table: "ContactInfo",
                column: "CustomerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCompanyInfo_CustomerID",
                schema: "cust",
                table: "CustomerCompanyInfo",
                column: "CustomerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerIndividualInfo_CustomerID",
                schema: "cust",
                table: "CustomerIndividualInfo",
                column: "CustomerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTrustInfo_CustomerID",
                schema: "cust",
                table: "CustomerTrustInfo",
                column: "CustomerID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address",
                schema: "cust");

            migrationBuilder.DropTable(
                name: "Branch",
                schema: "cust");

            migrationBuilder.DropTable(
                name: "BusinessType",
                schema: "cust");

            migrationBuilder.DropTable(
                name: "ContactInfo",
                schema: "cust");

            migrationBuilder.DropTable(
                name: "CustomerCompanyInfo",
                schema: "cust");

            migrationBuilder.DropTable(
                name: "CustomerIndividualInfo",
                schema: "cust");

            migrationBuilder.DropTable(
                name: "CustomerTrustInfo",
                schema: "cust");

            migrationBuilder.DropTable(
                name: "CustomerType",
                schema: "cust");

            migrationBuilder.DropTable(
                name: "EntityType",
                schema: "cust");

            migrationBuilder.DropTable(
                name: "JobStatusMaster",
                schema: "task");

            migrationBuilder.DropTable(
                name: "TaxAgent",
                schema: "cust");

            migrationBuilder.DropTable(
                name: "TradingStatus",
                schema: "cust");

            migrationBuilder.DropTable(
                name: "TypeMaster",
                schema: "task");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "cust");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "cust",
                table: "RelationShipType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "cust",
                table: "ContactType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
