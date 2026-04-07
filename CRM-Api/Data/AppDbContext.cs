using CRM_Api.Models;
using CRM_Api.Models.Entities.Customer;
using CRM_Api.Models.Entities.Operations;
using CRM_Api.Models.Entities.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRM_Api.Data
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ContactType> ContactTypes { get; set; } = null!;
        public DbSet<RelationShipType> RelationShipTypes { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<JobStatusMaster> JobStatusMasters { get; set; } = null!;
        public DbSet<TypeMaster> TypeMasters { get; set; } = null!;
        public DbSet<CustomerType> CustomerTypes { get; set; } = null!;
        public DbSet<BusinessType> BusinessTypes { get; set; } = null!;
        public DbSet<TaxAgent> TaxAgents { get; set; } = null!;
        public DbSet<TradingStatus> TradingStatuses { get; set; } = null!;
        public DbSet<EntityType> EntityTypes { get; set; } = null!;
        public DbSet<TaskAction> Actions { get; set; } = null!;
        public DbSet<TrustInfo> TrustInfos { get; set; } = null!;
        public DbSet<IndividualInfo> IndividualInfos { get; set; } = null!;
        public DbSet<CompanyInfo> CompanyInfos { get; set; } = null!;
        public DbSet<SolePropriterInfo> SolePropriterInfos { get; set; } = null!;
        public DbSet<ContactInfo> ContactInfos { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Detail> Details { get; set; } = null!;
        public DbSet<FileUploadInfo> FileUploadInfos { get; set; } = null!;
        public DbSet<BankAccount> BankAccounts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed ContactTypes
            modelBuilder.Entity<ContactType>().HasData(
                new ContactType { ID = 1, Name = "Client" },
                new ContactType { ID = 2, Name = "Prospect" },
                new ContactType { ID = 3, Name = "Lead" },
                new ContactType { ID = 4, Name = "Supplier" },
                new ContactType { ID = 5, Name = "Other" },
                new ContactType { ID = 6, Name = "Deregistered" },
                new ContactType { ID = 7, Name = "Moved to other accountants" },
                new ContactType { ID = 8, Name = "Bad clients" }
            );

            // Seed CustomerTypes
            modelBuilder.Entity<CustomerType>().HasData(
                new CustomerType { Id = 1, CustomerTypeNM = "Individual" },
                new CustomerType { Id = 2, CustomerTypeNM = "Company" },
                new CustomerType { Id = 3, CustomerTypeNM = "Sole Proprietor" },
                new CustomerType { Id = 4, CustomerTypeNM = "Trust" },
                new CustomerType { Id = 5, CustomerTypeNM = "AKA" },
                new CustomerType { Id = 6, CustomerTypeNM = "Partnership" },
                new CustomerType { Id = 7, CustomerTypeNM = "SMSF" },
                new CustomerType { Id = 8, CustomerTypeNM = "Staff" },
                new CustomerType { Id = 9, CustomerTypeNM = "Supplier" },
                new CustomerType { Id = 10, CustomerTypeNM = "Other" }
            );

            // Seed RelationShipTypes
            modelBuilder.Entity<RelationShipType>().HasData(
                new RelationShipType { ID = 1, Name = "Associate" },
                new RelationShipType { ID = 2, Name = "Banker" },
                new RelationShipType { ID = 3, Name = "Bookkeeper" },
                new RelationShipType { ID = 4, Name = "Director" },
                new RelationShipType { ID = 5, Name = "Lawyer" },
                new RelationShipType { ID = 6, Name = "Owner" },
                new RelationShipType { ID = 7, Name = "Professional advisor" },
                new RelationShipType { ID = 8, Name = "Partner" },
                new RelationShipType { ID = 9, Name = "Secretary" },
                new RelationShipType { ID = 10, Name = "Shareholder" },
                new RelationShipType { ID = 11, Name = "Subsidiary" },
                new RelationShipType { ID = 12, Name = "Trustee" },
                new RelationShipType { ID = 13, Name = "Beneficiary" }
            );

            // Seed JobStatusMaster
            modelBuilder.Entity<JobStatusMaster>().HasData(
                new JobStatusMaster { ID = 1, StatusName = "Not Yet In" },
                new JobStatusMaster { ID = 2, StatusName = "Allocated" },
                new JobStatusMaster { ID = 3, StatusName = "Active" },
                new JobStatusMaster { ID = 4, StatusName = "Pending" },
                new JobStatusMaster { ID = 5, StatusName = "Pre-Interview" },
                new JobStatusMaster { ID = 6, StatusName = "Draft" },
                new JobStatusMaster { ID = 7, StatusName = "Interviewed" },
                new JobStatusMaster { ID = 8, StatusName = "Finalising" },
                new JobStatusMaster { ID = 9, StatusName = "Complete" }
            );

            // Seed TypeMaster
            modelBuilder.Entity<TypeMaster>().HasData(
                new TypeMaster { ID = 1, Type = "Annual Accounts", ShortCode = "AA" },
                new TypeMaster { ID = 2, Type = "ASIC Updates", ShortCode = "ASIC" },
                new TypeMaster { ID = 3, Type = "BAS", ShortCode = "BAS" },
                new TypeMaster { ID = 4, Type = "Bookkeeping ", ShortCode = "BK" },
                new TypeMaster { ID = 5, Type = "Business Registration", ShortCode = "BREG" },
                new TypeMaster { ID = 6, Type = "Compliance", ShortCode = "COMP" },
                new TypeMaster { ID = 7, Type = "FBT", ShortCode = "FBT" },
                new TypeMaster { ID = 8, Type = "General Queries", ShortCode = "GQ" },
                new TypeMaster { ID = 9, Type = "Financial Statements", ShortCode = "FINS" },
                new TypeMaster { ID = 10, Type = "Income Tax Return", ShortCode = "ITR" },
                new TypeMaster { ID = 11, Type = "IAS", ShortCode = "IAS" },
                new TypeMaster { ID = 12, Type = "PAYG Summary", ShortCode = "PAYG" },
                new TypeMaster { ID = 13, Type = "Payroll", ShortCode = "PR" },
                new TypeMaster { ID = 14, Type = "Work Cover", ShortCode = "WC" },
                new TypeMaster { ID = 15, Type = "TFN Declaration", ShortCode = "TFN" },
                new TypeMaster { ID = 16, Type = "STP Finalisation", ShortCode = "STPF" },
                new TypeMaster { ID = 17, Type = "Others", ShortCode = "OTH" },
                new TypeMaster { ID = 18, Type = "Payroll Tax", ShortCode = "PR T" },
                new TypeMaster { ID = 19, Type = "Superannuation Guarantee", ShortCode = "SGC" },
                new TypeMaster { ID = 20, Type = "Taxable Payments Annual Repor", ShortCode = "TPAR" },
                new TypeMaster { ID = 21, Type = "TFN/ABN/PAYG Registration ", ShortCode = "REG" }
            );

            // Seed BusinessType (from old SSPCRM database)
            modelBuilder.Entity<BusinessType>().HasData(
                new BusinessType { Id = 1, BusinessTypeNM = "Restaurant" },
                new BusinessType { Id = 2, BusinessTypeNM = "Massage" },
                new BusinessType { Id = 3, BusinessTypeNM = "Education agent" },
                new BusinessType { Id = 4, BusinessTypeNM = "Car wash" },
                new BusinessType { Id = 5, BusinessTypeNM = "Real estate agent" },
                new BusinessType { Id = 6, BusinessTypeNM = "Mortgage broker" },
                new BusinessType { Id = 7, BusinessTypeNM = "Cafe" },
                new BusinessType { Id = 8, BusinessTypeNM = "Roof restoration" },
                new BusinessType { Id = 9, BusinessTypeNM = "Tiler" },
                new BusinessType { Id = 10, BusinessTypeNM = "Plumber" },
                new BusinessType { Id = 11, BusinessTypeNM = "Electrician" },
                new BusinessType { Id = 12, BusinessTypeNM = "Air conditioner mechanic" },
                new BusinessType { Id = 13, BusinessTypeNM = "House builder" },
                new BusinessType { Id = 14, BusinessTypeNM = "Transport" },
                new BusinessType { Id = 15, BusinessTypeNM = "GYM" },
                new BusinessType { Id = 16, BusinessTypeNM = "Education institute" },
                new BusinessType { Id = 17, BusinessTypeNM = "Tattoo Artist" },
                new BusinessType { Id = 18, BusinessTypeNM = "Accounting Firm" },
                new BusinessType { Id = 19, BusinessTypeNM = "Panel Beater" },
                new BusinessType { Id = 20, BusinessTypeNM = "Painter" }
            );

            // Seed TradingStatus (from old SSPCRM database)
            modelBuilder.Entity<TradingStatus>().HasData(
                new TradingStatus { Id = 1, Name = "Active But Not Trading" },
                new TradingStatus { Id = 2, Name = "Trading Quarterly" },
                new TradingStatus { Id = 3, Name = "Trading Annually" },
                new TradingStatus { Id = 4, Name = "Not active & not trading" }
            );

            // Seed TaxAgent
            modelBuilder.Entity<TaxAgent>().HasData(
                new TaxAgent { Id = 1, Name = "Internal Agent" },
                new TaxAgent { Id = 2, Name = "External Agent" }
            );

            // Seed Identity Roles
            modelBuilder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int> { Id = 2, Name = "Checker", NormalizedName = "CHECKER" },
                new IdentityRole<int> { Id = 3, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" }
            );
        }
    }
}
