using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM_Api.Models.Entities.DynamicFields;
using CRM_Api.Models.Base;

namespace CRM_Api.Models.Entities.Customer
{
    [Table("Customers", Schema = "cust")]
    public class Customer : EntityBase, IApiResultModel
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;
        [StringLength(15)]
        public string? Code { get; set; }

        [Required]
        public int ClientType { get; set; }

        [StringLength(50)]
        public string? FirmType { get; set; }
        public string? ABNNumber { get; set; }
        public string? BalanceDate { get; set; }
        public bool? BillingEntity { get; set; }
        public string? Class { get; set; }
        public bool? Client { get; set; }
        public string? ClientFrom { get; set; }
        public string? ClientTypeSubcategory { get; set; }
        public string? Facsimile { get; set; }
        public string? GSTBasis { get; set; }
        public string? GSTPeriod { get; set; }
        public bool? GSTRegistered { get; set; }
        public string? InBusinessSince { get; set; }
        public string? InvoiceDeliveryBy { get; set; }
        public string? MailingName { get; set; }
        public string? Manager { get; set; }
        public string? Partner { get; set; }
        public bool? PostNewsLetter { get; set; }
        public bool? PrepareGST { get; set; }
        public string? TFNNumber { get; set; }
        public string? TaxAgent { get; set; }
        public string? TaxReturnType { get; set; }
        public bool? AnnualFinancialStatements { get; set; }
        public bool? AnnualABNTaxReturn { get; set; }
        public bool? AnnualGSTClient { get; set; }
        public bool? AnnualNonGST { get; set; }
        public bool? BASA { get; set; }
        public bool? BASQ { get; set; }
        public bool? PrepareGroupCertificates { get; set; }
        public bool? Lodgement { get; set; }
        public bool? FinancialStatement { get; set; }
        public bool? PAYGWeekly { get; set; }
        public bool IsDeleted { get; set; }
        public int? ContactType { get; set; }
        public string? TradingName { get; set; }
        public bool? IsActive { get; set; }
        public int? LastVarifiedBy { get; set; }
        public DateTime? LastVarifiedDate { get; set; }
        public int? BusinessType { get; set; }
        public bool? IsArchived { get; set; }
        public int? TradingStatus { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsExcluded { get; set; }
        public int? StaffInCharge { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
        public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();
        public virtual IndividualInfo? IndividualInfo { get; set; }
        public virtual CompanyInfo? CompanyInfo { get; set; }
        public virtual TrustInfo? TrustInfo { get; set; }
        public virtual SolePropriterInfo? SolePropriterInfo { get; set; }
        public virtual ContactInfo? ContactInfo { get; set; }
        public virtual ICollection<CustomerServiceDetail> Services { get; set; } = new List<CustomerServiceDetail>();
        public virtual ICollection<DynamicFieldValue> DynamicFieldValues { get; set; } = new List<DynamicFieldValue>();
        public virtual ICollection<CustomerFSNote> FSNotes { get; set; } = new List<CustomerFSNote>();
    }

    [Table("Address", Schema = "cust")]
    public class Address : EntityBase, IApiResultModel
    {
        [Required]
        public int? CustomerID { get; set; }
        public int? Type { get; set; }
        public string? Addressee { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int? BranchID { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
    }

    [Table("ContactInfo", Schema = "cust")]
    public class ContactInfo : EntityBase, IApiResultModel
    {
        [Required]
        public int CustomerID { get; set; }
        public string? Salutation { get; set; }

        [StringLength(250)]
        public string? ContactName { get; set; }

        [StringLength(50)]
        public string? CellPhonePersonName { get; set; }

        [StringLength(16)]
        public string? CellPhone { get; set; }
        [StringLength(50)]
        public string? HomePhonePersonName { get; set; }

        [StringLength(16)]
        public string? HomePhone { get; set; }
        [StringLength(50)]
        public string? WorkPhonePersonName { get; set; }

        [StringLength(16)]
        public string? WorkPhone { get; set; }

        [StringLength(255)]
        public string? Email { get; set; }
        [StringLength(255)]
        public string? Email2 { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
    }

    [Table("Branch", Schema = "cust")]
    public class Branch : EntityBase, IApiResultModel
    {
        public string? BranchName { get; set; }
        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
    }

    [Table("CustomerIndividualInfo", Schema = "cust")]
    public class IndividualInfo : EntityBase, IApiResultModel
    {
        [Required]
        public int CustomerID { get; set; }
        [StringLength(150)]
        public string? FirstName { get; set; }
        [StringLength(150)]
        public string? LastName { get; set; }
        [StringLength(50)]
        public string? Title { get; set; }
 
        public int? Gender { get; set; }
        [Column("DateOfBirth", TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        public bool? ChargeInterest { get; set; }
        public bool? ChargeMonthlyDisbursement { get; set; }
        public string? BirthCountry { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public bool? NonResidentClient { get; set; }
        public string? TFNDivisionNumber { get; set; }
        public string? TitleAbbreviated { get; set; }
        public string? TitleFull { get; set; }
        public bool? ABNContractor { get; set; }
        public bool? BASM { get; set; }
        public bool? DASP { get; set; }
        public bool? IndividualTaxReturn { get; set; }
        public string? DirectorID { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
    }

    [Table("CustomerCompanyInfo", Schema = "cust")]
    public class CompanyInfo : EntityBase, IApiResultModel
    {
        [Required]
        public int? CustomerID { get; set; }
        public int? NoOfEmployee { get; set; }
        public string? WebSite { get; set; }
        public string? ABVDevisionNo { get; set; }
        public string? ACNNumber { get; set; }
        public string? ASICCompanyReviewDate { get; set; }
        public string? AccountingSoftware { get; set; }
        public string? AnnualAccountsMonth { get; set; }
        public string? Background { get; set; }
        public string? ContactGroup { get; set; }
        public bool? FiledbyFirm { get; set; }
        public bool? NonResidentClient { get; set; }
        public bool? AccountingSoftware2 { get; set; }
        public string? ClassOfClients { get; set; }
        public string? ToEmailForBASReports { get; set; }
        public bool? SuperContribution { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
    }

    [Table("CustomerTrustInfo", Schema = "cust")]
    public class TrustInfo : EntityBase, IApiResultModel
    {
        [Required]
        public int? CustomerID { get; set; }
        public string? AnnualAccountsMonth { get; set; }
        public bool? ChargeInterest { get; set; }
        public bool? ChargeMonthlyDisbursement { get; set; }
        public bool? FiledbyFirm { get; set; }
        public bool? NonResidentClient { get; set; }
        public bool? BASM { get; set; }
        public bool? DASP { get; set; }
        public bool? SuperContribution { get; set; }
        public bool? SuperHardship { get; set; }
        public bool? WorkerCompensation { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
    }

    [Table("CustomerSolePropriterInfo", Schema = "cust")]
    public class SolePropriterInfo : EntityBase, IApiResultModel
    {
        [Required]
        public int CustomerID { get; set; }
        [StringLength(150)]
        public string? FirstName { get; set; }
        [StringLength(150)]
        public string? LastName { get; set; }
        [StringLength(50)]
        public string? Title { get; set; }
        public string? ABNDivisionNumber { get; set; }
        public string? ClassOfClients { get; set; }
        public bool? FiledbyFirm { get; set; }
        public bool? ABNContractor { get; set; }
        public string? TitleAbbreviated { get; set; }
        public string? TitleFull { get; set; }
        public bool? DASP { get; set; }
        public bool? IndividualTaxReturn { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? DirectorID { get; set; }
        public string? BusinessName { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
    }

    [Table("BankAccount", Schema = "cust")]
    public class BankAccount : EntityBase, IApiResultModel
    {
        [Required]
        public int CustomerID { get; set; }
        [StringLength(150)]
        public string? AccountName { get; set; }
        [StringLength(150)]
        public string? BankName { get; set; }
        [StringLength(20)]
        public string? BSB { get; set; }
        [StringLength(50)]
        public string? AccountNumber { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; } = null!;
    }

    [Table("CustomerServices", Schema = "cust")]
    public class CustomerServiceDetail : EntityBase
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Amount { get; set; }
        [StringLength(10)]
        public string? Unit { get; set; } // y, q, m, w, d
        public string? InternalNotes { get; set; }
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }
        [ForeignKey("ServiceId")]
        public virtual ServiceMaster? Service { get; set; }
    }
}
