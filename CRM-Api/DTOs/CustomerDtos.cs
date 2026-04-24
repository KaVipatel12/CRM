using System;
using System.ComponentModel;

namespace CRM_Api.DTOs
{
    public class CustomerListFilter
    {
        public bool IncludeInactive { get; set; } = false;
        public int? ContactType { get; set; }
        public string? VarifiedType { get; set; }
        public string? OrderBy { get; set; }
        public string? SearchString { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public bool IncludeArchived { get; set; } = false;
        public bool IncludeExcluded { get; set; } = false;
    }

    public class CustomerListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Code { get; set; }
        public int ClientType { get; set; }
        public string? CustomerTypeNM { get; set; }
        public string? Email { get; set; }
        public int? ContactType { get; set; }
        public string? TradingName { get; set; }
        public bool? IsActive { get; set; }
        public int? LastVarifiedBy { get; set; }
        public DateTime? LastVarifiedDate { get; set; }
        public bool? IsArchived { get; set; }
        public bool? IsExcluded { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class CustomerDetailsDto : CustomerListDto
    {
        public string? LastVarifiedUserName { get; set; }
        public string? ABNNumber { get; set; }
        public string? TFNNumber { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        public string? Website { get; set; }
        public int? BusinessType { get; set; }
        public int? TradingStatus { get; set; }
        public int? TaxAgent { get; set; }
        public int? StaffInCharge { get; set; }
        public bool? PostNewsLetter { get; set; }
        public string? MailingName { get; set; }
        public string? Partner { get; set; }
        public string? Manager { get; set; }
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
        public List<AddressDto>? Addresses { get; set; }
        public ContactInfoDto? ContactInfo { get; set; }
        public IndividualInfoDto? IndividualInfo { get; set; }
        public CompanyInfoDto? CompanyInfo { get; set; }
        public TrustInfoDto? TrustInfo { get; set; }
        public SolePropriterInfoDto? SolePropriterInfo { get; set; }
        public List<BankAccountDto>? BankAccounts { get; set; }
    }

    public class CustomerSaveDto
    {
        public int Id { get; set; } // 0 for create, > 0 for update
        public string Name { get; set; } = string.Empty;
        public string? Code { get; set; }
        public int ClientType { get; set; }
        public string? TradingName { get; set; }
        public string? ABNNumber { get; set; }
        public string? TFNNumber { get; set; }
        public bool? IsActive { get; set; } = true;
        public int? ContactType { get; set; }
        public int? BusinessType { get; set; }
        public int? TradingStatus { get; set; }
        public int? TaxAgent { get; set; }
        public int? StaffInCharge { get; set; }
        public bool? PostNewsLetter { get; set; }
        public string? MailingName { get; set; }
        public string? Partner { get; set; }
        public string? Manager { get; set; }
        public bool? IsArchived { get; set; }
        public bool? IsExcluded { get; set; }

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

        public ContactInfoDto? ContactInfo { get; set; }
        public IndividualInfoDto? IndividualInfo { get; set; }
        public CompanyInfoDto? CompanyInfo { get; set; }
        public TrustInfoDto? TrustInfo { get; set; }
        public SolePropriterInfoDto? SolePropriterInfo { get; set; }
        public List<AddressDto>? Addresses { get; set; }
        public List<BranchDto>? Branches { get; set; }
        public List<BankAccountDto>? BankAccounts { get; set; }
        public List<UpsertDynamicFieldValueDto>? DynamicFieldValues { get; set; }
        public List<CreateCustomerRelationshipDto>? Relationships { get; set; }
    }

    public class ContactInfoDto
    {
        public int Id { get; set; }
        public string? Salutation { get; set; }
        public string? ContactName { get; set; }
        public string? CellPhone { get; set; }
        public string? WorkPhone { get; set; }
        public string? Email { get; set; }
        public string? Email2 { get; set; }
    }

    public class IndividualInfoDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string? DirectorID { get; set; }
        public bool? ChargeInterest { get; set; }
        public bool? ChargeMonthlyDisbursement { get; set; }
    }

    public class CompanyInfoDto
    {
        public int Id { get; set; }
        public string? WebSite { get; set; }
        public string? ACNNumber { get; set; }
        public string? AnnualAccountsMonth { get; set; }
    }

    public class TrustInfoDto
    {
        public int Id { get; set; }
        public string? AnnualAccountsMonth { get; set; }
        public bool? ChargeInterest { get; set; }
        public bool? ChargeMonthlyDisbursement { get; set; }
        public bool? FiledbyFirm { get; set; }
    }

    public class SolePropriterInfoDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? DirectorID { get; set; }
        public string? BusinessName { get; set; }
    }

    public class AddressDto
    {
        public int Id { get; set; }
        public int? Type { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public int? BranchID { get; set; }
        public string? BranchName { get; set; }
    }

    public class BankAccountDto
    {
        public int Id { get; set; }
        public string? AccountName { get; set; }
        public string? BankName { get; set; }
        public string? BSB { get; set; }
        public string? AccountNumber { get; set; }
    }

    public class ChangeTypeRequestDto
    {
        public int NewClientType { get; set; }
    }

    public class CustomerStatisticsDto
    {
        public int Total { get; set; }
        public int Verified { get; set; }
        public int Unverified { get; set; }
        public int Active { get; set; }
        public int Inactive { get; set; }
    }

    public class CustomerPagedResponseDto
    {
        public List<CustomerListDto> Items { get; set; } = new();
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }

    public class CustomerServiceDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public decimal? Amount { get; set; }
        public string? Unit { get; set; }
        public string? InternalNotes { get; set; }

        // Tracking info
        public int? UpdateUserId { get; set; }
        public string? UpdateUserName { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }

    public class ServiceMasterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class BranchDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? BranchName { get; set; }
    }
}
